using Microsoft.AspNetCore.Identity;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Models;

namespace QLHV_BackEnd.Repositories
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> CheckEmail(string email);
        Task<SignInResult> CheckPassword(SignInModel signInModel);
        string GenerateJwtToken(ApplicationUser user);
    }
}
