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

namespace TMS.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<(IdentityResult, RegisterUserResponse)> RegisterUser(RegisterUserRequest request);
        Task<bool?> DesactiveUser(Guid id);
        Task<IdentityResult> UpdateUser(Guid id, RegisterUserResponse request);
        Task<List<UserModel>> ListAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task<UserModel> GetUserByEmail(string email);
        Task<List<UserModel>> ListAllActivedUsers();
        Task<List<UserModel>> ListAllDesactivedUsers();
        Task<UserModel> ValidateUser(string email, string password);
    }
}
