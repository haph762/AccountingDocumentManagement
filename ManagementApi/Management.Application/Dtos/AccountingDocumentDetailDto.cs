namespace Management.Application.Dtos
{
    public class AccountingDocumentDetailDto
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty; // "Debit" hoặc "Credit"
    }
}
