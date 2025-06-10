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
            
            userToUpdate.UpdateUser(
                request.FirstName, 
                request.LastName, 
                request.Email,      
                request.TaxId,      
                request.PhoneNumber 
            );
            
            return await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task<UserModel> GetUserByEmail(EmailVO email)
        {
            var user = await _userRepository.GetByEmailAsync(email.Value); 
            if (user == null)
            {
                _logger.LogWarning($"User with email {email} not found");
            }
            return user;
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
        
        public async Task<UserModel> ValidateUser(EmailVO email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email.Value);
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
            var emailVO = new EmailVO(request.Email);
            var phoneVO = new PhoneVO(request.PhoneNumber);
            var taxIdVO = new TaxIdVO(request.TaxId);
            
            var newUser = new UserModel(
                request.FirstName,
                request.LastName,
                emailVO,
                taxIdVO,
                phoneVO
            );
            
            var result = await _userRepository.AddAsync(newUser, request.Password);
            
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {newUser.Email} created");
                var response = new RegisterUserResponse
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.EmailVO,
                    PhoneNumber = newUser.PhoneVO,
                    TaxId = newUser.TaxId
                };
                return (result, response);
            }
            
            _logger.LogError($"Failed to create user {newUser.Email}.");
            return (result, null);
        }
    }
}
