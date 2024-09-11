using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLHV_BackEnd.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<ApplicationUser> CheckEmail(string email)
        {
            return await userManager.FindByNameAsync(email);
        }
        public async Task<SignInResult> CheckPassword(SignInModel signInModel)
        {
            return await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
        }
        public string GenerateJwtToken(ApplicationUser user)
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var roles = userManager.GetRolesAsync(user: user).Result;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
