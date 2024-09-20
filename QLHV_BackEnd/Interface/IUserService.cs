using Microsoft.AspNetCore.Identity;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Model;

namespace QLHV_BackEnd.Interface
{
    public interface IUserService
    {
        Task GetUserByEmailToRegister(string email);
        Task<IdentityResult> CreateUser(RegisterModel registerModel);
        Task<int> UpdateUser(string id, UserModel userModel);
        Task<int> DeleteUser(string id);

    }
}
