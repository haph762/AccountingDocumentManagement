using Management.Application.Dtos;
using Management.Application.Mapping;
using Management.Domain;
using Management.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingDocumentsController : ControllerBase
    {
        private readonly IAccountingDocumentRepository _repository;

        public AccountingDocumentsController(IAccountingDocumentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _repository.GetAllAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null) return NotFound();
            AccountingDocumentDto dto = document.ToDto();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountingDocumentDto document)
        {
            try
            {
                AccountingDocument model = document.ToModel();
                await _repository.AddAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = document.Id }, document);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = "Kiểm tra lại thông tin chứng từ" });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AccountingDocumentDto document)
        {
            AccountingDocument model = document.ToModel();
            if (id != document.Id) return BadRequest();
            await _repository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetailsByDocumentId(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null) return NotFound("Không tìm thấy chứng từ.");

            return Ok(document.Details);
        }

    }

}
