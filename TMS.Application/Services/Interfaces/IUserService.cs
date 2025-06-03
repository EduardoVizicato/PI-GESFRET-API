using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entites.Requests.User;
using TMS.Domain.Entites.Responses.User;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool?> RegisterUser(RegisterUserRequest request);
        Task<bool?> DesactiveUser(Guid id);
        Task<bool?> UpdateUser(Guid id, RegisterUserResponse request);
        Task<List<UserModel>> ListAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task<UserModel> GetUserByEmail(EmailVO email);
        Task<List<UserModel>> ListAllActivedUsers();
        Task<List<UserModel>> ListAllDesactivedUsers();
        Task<UserModel> ValidateUser(EmailVO email, PasswordVO password);
    }
}
