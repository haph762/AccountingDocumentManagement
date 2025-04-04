namespace Management.Application.Dtos
{
    public class AccountingDocumentDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<AccountingDocumentDetailDto> Details { get; set; } = new List<AccountingDocumentDetailDto>();
    }
}
