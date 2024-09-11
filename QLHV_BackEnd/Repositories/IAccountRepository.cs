using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Helpers;
using QLHV_BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLHV_BackEnd.Repositories
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}
