using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLHV_BackEnd.Data.Entity;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AuthController(IAuthService authService, IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            this.authService = authService;
            this.userService = userService;
            this.signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await authService.CheckUser(model.Email);
            if (result == null)
            {
                return Unauthorized("Không tìm thấy người dùng");
            }
            var resultPassword = await authService.CheckPassword(model);
            if (!resultPassword.Succeeded)
            {
                return Unauthorized("Không đúng mật khẩu");
            }
            (var token, IEnumerable<string> roles) = authService.GenerateJwtToken(result);
            return Ok(new
            {
                access_token = token,
                token_type = "JWT",
                auth_type = "Bearer",
                expires_in = DateTime.UtcNow.AddHours(1),
                user = new
                {
                    userName = result.UserName,
                    email = result.Email,
                    role = roles
                }
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Exception("BadRequest"));
            }
            else
            {
                try
                {
                    await userService.GetUserByEmailToRegister(model.Email);
                    await userService.CreateUser(model);
                    return Ok("Tạo thành công");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        Success = false,
                        Message = "An error occurred while processing your request",
                        Error = ex.Message
                    });
                }
            }
        }
    }
}
