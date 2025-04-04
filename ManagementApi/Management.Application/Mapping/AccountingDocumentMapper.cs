using Management.Application.Dtos;
using Management.Domain;

namespace Management.Application.Mapping
{
    public static class AccountingDocumentMapper
    {
        public static AccountingDocumentDto ToDto(this AccountingDocument accountingDocument)
        {
            return new AccountingDocumentDto
            {
                Id = accountingDocument.Id,
                Description = accountingDocument.Description,
                Details = accountingDocument.Details.Select(d => d.ToDto()).ToList(),
                DocumentDate = accountingDocument.DocumentDate,
                DocumentNumber = accountingDocument.DocumentNumber,
                DocumentType = accountingDocument.DocumentType,
                TotalAmount = accountingDocument.TotalAmount
            };
        }

        public static AccountingDocument ToModel(this AccountingDocumentDto accountingDocumentDto)
        {
            return new AccountingDocument
            {
                Id = accountingDocumentDto.Id,
                Description = accountingDocumentDto.Description,
                Details = accountingDocumentDto.Details.Select(d => d.ToModel()).ToList(),
                TotalAmount = accountingDocumentDto.TotalAmount,
                DocumentType = accountingDocumentDto.DocumentType,
                DocumentDate = accountingDocumentDto.DocumentDate,
                DocumentNumber = accountingDocumentDto.DocumentNumber,
            };
        }
    }
}
