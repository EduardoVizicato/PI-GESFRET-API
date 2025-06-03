using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Task<UserModel> GetUserByEmail(EmailVO email);
        Task<UserModel> AddAsync(UserModel user);
        Task<bool?> UpdatesUserAsync(Guid id,RegisterUserResponse user);
        Task<bool?> DesactiveUserAsync(Guid id);
        Task<List<UserModel>> GetAllActivedUsers();
        Task<List<UserModel>> GetAllDesactivedUsers();
    }
}
