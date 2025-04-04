using Management.Domain;
using Management.Infrastructure.Data;
using Management.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Management.Infrastructure.Repositories.Implementations
{
    public class AccountingDocumentRepository : IAccountingDocumentRepository
    {
        private readonly AccountingDbContext _context;

        public AccountingDocumentRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountingDocument>> GetAllAsync()
            => await _context.AccountingDocuments.Include(d => d.Details).ToListAsync();

        public async Task<AccountingDocument?> GetByIdAsync(int id)
            => await _context.AccountingDocuments.Include(d => d.Details).FirstOrDefaultAsync(d => d.Id == id);

        public async Task AddAsync(AccountingDocument document)
        {
            if (document.Details != null && document.Details.Count > 0)
            {
                var totalAmount = document.Details.Sum(d => d.Amount);
                if (totalAmount != document.TotalAmount)
                    throw new InvalidOperationException("Tổng tiền không khớp với tổng số tiền chi tiết.");
            }

            await _context.AccountingDocuments.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AccountingDocument document)
        {
            if (document.Details != null && document.Details.Count > 0)
            {
                var totalAmount = document.Details.Sum(d => d.Amount);
                if (totalAmount != document.TotalAmount)
                    throw new InvalidOperationException("Tổng tiền không khớp với tổng số tiền chi tiết.");
            }

            _context.AccountingDocuments.Update(document);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var document = await _context.AccountingDocuments.FindAsync(id);
            if (document != null)
            {
                _context.AccountingDocuments.Remove(document);
                await _context.SaveChangesAsync();
            }
        }
    }

}
