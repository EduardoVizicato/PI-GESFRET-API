using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TMS.Domain.Entites.Requests.User;
using TMS.Domain.Entites.Responses.User;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(Guid id);
        Task<UserModel> GetByEmailAsync(string email);
        Task<IdentityResult> AddAsync(UserModel user, string password);
        Task<IdentityResult> UpdateAsync(UserModel user);
        Task<bool?> DesactiveUserAsync(Guid id);
        Task<List<UserModel>> GetAllActivedUsers();
        Task<List<UserModel>> GetAllDesactivedUsers();
        Task<bool?> DeleteUser(Guid id);
    }
}
