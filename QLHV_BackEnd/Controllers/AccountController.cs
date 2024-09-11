using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV_BackEnd.Models;
using QLHV_BackEnd.Repositories;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthRepository _authRepository;
        public AccountController(IAccountRepository accountRepository, IAuthRepository authRepository)
        {
            _accountRepository = accountRepository;
            _authRepository = authRepository;
        }
        [HttpPost("Sign In")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _authRepository.CheckEmail(signInModel.Email);
            if (result == null)
            {
                return Unauthorized("Không tìm thấy người dùng");
            }
            var resultPassword = await _authRepository.CheckPassword(signInModel);
            if (!resultPassword.Succeeded)
            {
                return Unauthorized("Không đúng mật khẩu");
            }
            var token = _authRepository.GenerateJwtToken(result);
            return Ok(new
            {
                access_token = token,
                token_type = "JWT",
                auth_type = "Bearer",
                expires_in = DateTime.UtcNow.AddHours(1),
                user = new
                {
                    userName = result.UserName,
                    email = result.Email
                }
            });

        }
        [HttpPost("Sign Up")]
        public async Task<IActionResult> Register([FromBody] SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingUser = await _accountRepository.GetUserByEmail(signUpModel.Email);
            if (existingUser != null)
            {
                return Conflict("User đã tồn tại!");
            }
            var result = await _accountRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok("Tạo thành công");
            }
            return StatusCode(500, "Lỗi khi tạo người dùng");
        }
    }
}
