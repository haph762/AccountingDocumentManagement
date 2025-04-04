namespace Management.Domain
{
    public class AccountingDocument
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<AccountingDocumentDetail> Details { get; set; } = new List<AccountingDocumentDetail>();
    }

}
