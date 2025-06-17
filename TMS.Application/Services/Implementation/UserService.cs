using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Microsoft.AspNetCore.Identity;
using TMS.Application.Common.Interface.Authentication;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites.Requests.User;
using TMS.Domain.Entites.Responses.User;
using TMS.Domain.Entities;
using TMS.Domain.Repositories;
using TMS.Domain.ValueObjects;

namespace TMS.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<UserModel> _userManager;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger,  UserManager<UserModel> userManager)
        {
            _userRepository = userRepository;
            _logger = logger;
            _userManager = userManager;
        }
        public Task<bool?> DesactiveUser(Guid id)
        {
            var desactiveUser = _userRepository.DesactiveUserAsync(id);
            return desactiveUser;
        }

        public async Task<IdentityResult> UpdateUser(Guid id, RegisterUserResponse request)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                _logger.LogError($"Update failed: User with id {id} not found.");
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            
            return await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await  _userRepository.GetByEmailAsync(email);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with id {id} not found");
            }
            return user;
        }

        public Task<List<UserModel>> ListAllActivedUsers()
        {
            var getAllActivedUsers = _userRepository.GetAllActivedUsers();
            return getAllActivedUsers;
        }

        public Task<List<UserModel>> ListAllDesactivedUsers()
        {
            var listAllDesactivedUsers = _userRepository.GetAllDesactivedUsers();
            return listAllDesactivedUsers;
        }
        

        public async Task<UserModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning($"User with email {email} not found.");
                return null; 
            }
            var isPasswordCorrect = await _userRepository.CheckPasswordAsync(user, password);

            if (isPasswordCorrect)
            {
                _logger.LogInformation($"User {email} validated successfully.");
                return user;
            }
            else
            {
                _logger.LogWarning($"Validation failed: invalid password for user {email}.");
                return null;
            }
        }

        public Task<List<UserModel>> ListAllUsers()
        {
            var listAllUsers = _userRepository.GetAllAsync();
            return listAllUsers;
        }

        public async Task<(IdentityResult, RegisterUserResponse)> RegisterUser(RegisterUserRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                var emailError = new IdentityError { Code = "DuplicateEmail", Description = "This email is already registered." };
                return (IdentityResult.Failed(emailError), null);
            }
            
            var newUser = new UserModel(
                request.FirstName,
                request.LastName,
                request.TaxId
            );
            
            newUser.Email = request.Email;
            newUser.UserName = request.Email; 
            newUser.PhoneNumber = request.PhoneNumber;
            
            var identityResult = await _userRepository.AddAsync(newUser, request.Password);
            
            if (!identityResult.Succeeded)
                return (identityResult, null);
            
            
            var response = new RegisterUserResponse
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                TaxId = newUser.TaxId,
                PhoneNumber = newUser.PhoneNumber,
                CreatedAt = newUser.CreatedAt
            };

            // 8. Return the success result and the mapped response.
            return (identityResult, response);
        }
    }
}