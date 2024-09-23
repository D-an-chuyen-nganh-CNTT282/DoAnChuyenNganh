using Microsoft.AspNetCore.Identity;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Model.UserModel;

namespace QLHV_BackEnd.Interface
{
    public interface IAuthService
    {
        Task<ApplicationUser> CheckUser(string userName);
        Task<SignInResult> CheckPassword(LoginModel loginModel);
        (string token, IEnumerable<string> roles) GenerateJwtToken(ApplicationUser user);
    }
}
