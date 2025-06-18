using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TMS.Domain.Entites.Requests.User;
using TMS.Domain.Entites.Responses.User;
using TMS.Domain.Entities;
using TMS.Domain.Repositories;
using TMS.Domain.ValueObjects;
using TMS.Infrastructure.Data;

namespace TMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;
        private readonly ILogger<UserRepository> _logger;
        private readonly UserManager<UserModel> _userManager;
        
        public UserRepository(ApplicationDataContext context, ILogger<UserRepository> logger, UserManager<UserModel> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<bool?> DesactiveUserAsync(Guid id)
        {
            var userToDesactive = await _context.Users.FindAsync(id);
            userToDesactive.IsActive = false;
            await _context.SaveChangesAsync();
            _logger.LogError($"Usuário de Id {id} desativado com sucesso");
            return true;
        }

        public async Task<List<UserModel>> GetAllActivedUsers()
        {
            return await _context.Users.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            _logger.LogInformation("Carregando todos os usuários");
            return await _context.Users.ToListAsync();
        }

        public async Task<List<UserModel>> GetAllDesactivedUsers()
        {
            return await _context.Users.Where(x => x.IsActive == false).ToListAsync();
        }

        public async Task<bool> CheckPasswordAsync(UserModel user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Fetching user by id {id}");
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            _logger.LogInformation($"Fetching user by email {email}");
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> AddAsync(UserModel user, string password)
        {
            _logger.LogInformation($"Attempting to create user: {user.Email}");
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Error creating user {user.Email}: Code={error.Code}, Description={error.Description}");
                }
            }
            else
            {
                _logger.LogInformation($"Successfully created user: {user.Email}");
            }

            return result;
        }

        public async Task<IdentityResult> UpdateAsync(UserModel user)
        {
            _logger.LogInformation($"Updating user{user.Id}");
            return await _userManager.UpdateAsync(user);
        }
    }
}
