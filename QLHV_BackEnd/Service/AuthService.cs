using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLHV_BackEnd.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<ApplicationUser> CheckUser(string email)
        {
            return await userManager.FindByNameAsync(email);
        }
        public async Task<SignInResult> CheckPassword(LoginModel loginModel)
        {
            return await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
        }
        public (string token, IEnumerable<string> roles) GenerateJwtToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(configuration["JWT:SecretKey"]);
            var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
            };
            IEnumerable<string> roles = userManager.GetRolesAsync(user: user).Result;
            foreach (string role in roles)
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
            return (tokenHandler.WriteToken(token), roles);
        }
    }
}
