using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV_BackEnd.Interface;
using QLHV_BackEnd.Model.GiangVienModel;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        public readonly IGiangVienService giangVienService;
        public GiangVienController(IGiangVienService giangVienService)
        {
            this.giangVienService = giangVienService;
        }
        [HttpGet("GetAllGiangVien")]
        public async Task<IActionResult> GetAllGiangViens()
        {
            var giangviens = await giangVienService.GetGiangViens();
            return Ok(giangviens);
        }
        [HttpPost("CreateGiangVien")]
        public async Task<IActionResult> CreateGiangVien([FromBody] CreateGiangVienModel createGiangVienModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int rowChange = await giangVienService.CreateGiangVien(createGiangVienModel);
            if (rowChange > 0)
            {
                return Ok("Thông tin giảng viên được thêm thành công");
            }
            return StatusCode(500, "Lỗi server");
        }
        [HttpPut("UpdateGiangVien")]
        public async Task<IActionResult> UpdateGiangVien([FromQuery] int id, [FromBody] UpdateGiangVienModel updateGiangVienModel)
        {
            int rowChange = await giangVienService.UpdateGiangVien(id, updateGiangVienModel);
            if (rowChange > 0)
            {
                return Ok("Đã sửa thông tin giảng viên");
            }
            return NotFound();
        }
        [HttpDelete("DeleteGiangVien")]
        public async Task<IActionResult> DeleteGiangVien([FromQuery] int id)
        {
            int rowChange = await giangVienService.DeleteGiangVien(id);
            if (rowChange > 0)
            {
                return Ok("Đã xóa thông tin giảng viên");
            }
            return NotFound();
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = await giangVienService.Pagination(pageSize, pageNumber);
            return Ok(result);
        }
    }
}
