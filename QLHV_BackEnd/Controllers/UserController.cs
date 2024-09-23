using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.UserModel;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users)
                ;
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            int rowChange = await _userService.DeleteUser(id);
            if (rowChange > 0)
            {
                return Ok("Xóa tài khoản thành công");
            }
            return NotFound();
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string id, UserModel user)
        {
            int rowChange = await _userService.UpdateUser(id, user);
            if (rowChange > 0)
            {
                return Ok("Cập nhật tài khoản thành công");
            }
            return NotFound();
        }
    }
}
