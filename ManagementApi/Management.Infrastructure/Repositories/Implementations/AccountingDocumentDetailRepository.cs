using Management.Domain;
using Management.Infrastructure.Data;
using Management.Infrastructure.Repositories.Interfaces;

namespace Management.Infrastructure.Repositories.Implementations
{
    public class AccountingDocumentDetailRepository : IAccountingDocumentDetailRepository
    {
        private readonly AccountingDbContext _context;

        public AccountingDocumentDetailRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task AddDetailAsync(AccountingDocumentDetail detail)
        {
            if (detail.Amount <= 0)
                throw new InvalidOperationException("Số tiền phải lớn hơn 0.");

            if (detail.TransactionType != "Debit" && detail.TransactionType != "Credit")
                throw new InvalidOperationException("Loại giao dịch chỉ có thể là 'Debit' hoặc 'Credit'.");

            await _context.AccountingDocumentDetails.AddAsync(detail);
            await _context.SaveChangesAsync();
        }
    }

}
