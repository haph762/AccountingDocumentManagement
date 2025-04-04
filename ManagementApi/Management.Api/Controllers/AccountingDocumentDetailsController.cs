using Management.Application.Dtos;
using Management.Application.Mapping;
using Management.Domain;
using Management.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingDocumentDetailsController : ControllerBase
    {
        private readonly AccountingDbContext _context;

        public AccountingDocumentDetailsController(AccountingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail([FromBody] AccountingDocumentDetailDto detail)
        {
            if (detail.Amount <= 0)
                return BadRequest(new { message = "Số tiền phải lớn hơn 0." });

            if (detail.TransactionType != "Debit" && detail.TransactionType != "Credit")
                return BadRequest(new { message = "Loại giao dịch không hợp lệ." });

            AccountingDocumentDetail model = detail.ToModel();
            _context.AccountingDocumentDetails.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetailById), new { id = detail.Id }, detail);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            var detail = await _context.AccountingDocumentDetails.FindAsync(id);
            if (detail == null) return NotFound();
            AccountingDocumentDetailDto dto = detail.ToDto();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetail(int id, [FromBody] AccountingDocumentDetailDto detail)
        {
            if (id != detail.Id) return BadRequest();

            AccountingDocumentDetail model = detail.ToModel();
            _context.AccountingDocumentDetails.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            var detail = await _context.AccountingDocumentDetails.FindAsync(id);
            if (detail == null) return NotFound();

            _context.AccountingDocumentDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
