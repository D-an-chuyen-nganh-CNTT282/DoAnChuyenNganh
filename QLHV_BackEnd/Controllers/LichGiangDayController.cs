using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.LichGiangDayModel;
using System.Security.Claims;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichGiangDayController : ControllerBase
    {
        public readonly ILichGiangDayService lichGiangDayService;
        public LichGiangDayController(ILichGiangDayService lichGiangDayService) 
        {
            this.lichGiangDayService = lichGiangDayService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLichGiangDays()
        {
            var lgds = await lichGiangDayService.GetLichGiangDays();
            return Ok(lgds);
        }
        [HttpPost("CreateLichGiangDay")]
        public async Task<IActionResult> CreateLichGiangDay([FromBody] CreateLichGiangDayModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int rowChange = await lichGiangDayService.CreateLichGiangDay(model, userName);
            if (rowChange > 0)
            {
                return Ok("Thêm mới lịch giảng dạy thành công");
            }
            return StatusCode(500, "Lỗi server");
        }
        [HttpPut("UpdateLichGiangDay")]
        public async Task<IActionResult> UpdateLichGiangDay([FromQuery] int id, [FromBody] UpdateLichGiangDayModel model)
        {
            int rowChange = await lichGiangDayService.UpdateLichGiangDay(id, model);
            if (rowChange > 0)
            {
                return Ok("Cập nhật thành công");
            }
            return NotFound();
        }
        [HttpDelete("DeleteLichGiangDay")]
        public async Task<IActionResult> DeleteLichGiangDay([FromQuery] int id)
        {
            int rowChange = await lichGiangDayService.DeleteLichGiangDay(id);
            if (rowChange > 0)
            {
                return Ok("Xóa lịch thành công");
            }
            return NotFound();
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = await lichGiangDayService.Pagination(pageSize, pageNumber);
            return Ok(result);
        }
    }
}
