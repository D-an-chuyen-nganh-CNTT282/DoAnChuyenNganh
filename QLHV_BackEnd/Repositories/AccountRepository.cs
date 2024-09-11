using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Data.Entities;
using QLHV_BackEnd.Helpers;
using QLHV_BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLHV_BackEnd.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly DBContext _context;
        public AccountRepository(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var newUser = new ApplicationUser
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await _userManager.CreateAsync(newUser, signUpModel.Password);
        }
    }
}
