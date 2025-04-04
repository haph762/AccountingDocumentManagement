using Management.Application.Dtos;
using Management.Domain;

namespace Management.Application.Mapping
{
    public static class AccountingDocumentDetailMapper
    {
        public static AccountingDocumentDetailDto ToDto(this AccountingDocumentDetail accountingDocumentDetail)
        {
            return new AccountingDocumentDetailDto
            {
                Id = accountingDocumentDetail.Id,
                Description = accountingDocumentDetail.Description,
                Amount = accountingDocumentDetail.Amount,
                DocumentId = accountingDocumentDetail.DocumentId,
                AccountCode = accountingDocumentDetail.AccountCode,
                TransactionType = accountingDocumentDetail.TransactionType
            };
        }

        public static AccountingDocumentDetail ToModel(this AccountingDocumentDetailDto accountingDocumentDetailDto)
        {
            return new AccountingDocumentDetail
            {
                Id = accountingDocumentDetailDto.Id,
                Description = accountingDocumentDetailDto.Description,
                Amount = accountingDocumentDetailDto.Amount,
                DocumentId = accountingDocumentDetailDto.DocumentId,
                AccountCode = accountingDocumentDetailDto.AccountCode,
                TransactionType = accountingDocumentDetailDto.TransactionType
            };
        }
    }
}
