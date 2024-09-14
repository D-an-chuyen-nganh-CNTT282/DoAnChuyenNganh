using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV_BackEnd.Models;
using QLHV_BackEnd.Repositories;

namespace QLHV_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingDocumentController : ControllerBase
    {
        public readonly IIncomingDocumentRepository _incomingDocumentRepository;
        public IncomingDocumentController(IIncomingDocumentRepository incomingDocumentRepository)
        {
            _incomingDocumentRepository = incomingDocumentRepository;
        }
        [HttpGet("GetAllIncomingDocument")]
        public async Task<IActionResult> GetAllIncomingDocuments()
        {
            var incomingDocuments = await _incomingDocumentRepository.GetIncomingDocuments();
            return Ok(incomingDocuments);
        }
        [HttpGet("GetIncomingDocumentByTitle")]
        public async Task<IActionResult> GetIncomingDocumentByTitle(string title)
        {
            var incomingDocument = await _incomingDocumentRepository.GetIncomingDocumentByTitle(title);
            return Ok(incomingDocument);
        }
        //[HttpGet("GetIncomingDocumentByReceived")]
        //public async Task<IActionResult> GetIncomingDocumentByReceivedDate(DateTime receivedDate)
        //{
        //    var incomingDocument = await _incomingDocumentRepository.GetIncomingDocumentByReceivedDate(receivedDate);
        //    return Ok(incomingDocument);
        //}
        [HttpGet("GetIncomingDocumentBySender")]
        public async Task<IActionResult> GetIncomingDocumentBySender(string sender)
        {
            var incomingDocument = await _incomingDocumentRepository.GetIncomingDocumentBySender(sender);
            return Ok(incomingDocument);
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int pageSize, int pageNumber)
        {
            var result = await _incomingDocumentRepository.Pagination(pageSize, pageNumber);
            return Ok(result);
        }
        [HttpPost("CreateIncomingDocument")]
        public async Task<IActionResult> CreateIncomingDocument(CreateIncomingDocumentModel createIncomingDocumentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rowChange = await _incomingDocumentRepository.CreateIncomingDocument(createIncomingDocumentModel);
            if (rowChange > 0)
            {
                return Ok("Tạo công văn đến thành công");
            }
            return StatusCode(500, "Lỗi server");
        }
        [HttpPut("UpdateIncomingDocument")]
        public async Task<IActionResult> UpdateIncomingDocument(int incomingDocumentId, UpdateIncomingDocumentModel updateIncomingDocumentModel)
        {
            int rowChange = await _incomingDocumentRepository.UpdateIncomingDocument(incomingDocumentId, updateIncomingDocumentModel);
            if (rowChange > 0)
            {
                return Ok("Cập nhật công văn đến thành công");
            }
            return NotFound();
        }
        [HttpDelete("DeleteIncomingDocument")]
        public async Task<IActionResult> DeleteIncomingDocument(int incomingDocumentId)
        {
            int rowChange = await _incomingDocumentRepository.DeleteIncomingDocument(incomingDocumentId);
            if (rowChange > 0)
            {
                return Ok("Xóa công văn đến thành công");
            }
            return NotFound();
        }
    }
}
