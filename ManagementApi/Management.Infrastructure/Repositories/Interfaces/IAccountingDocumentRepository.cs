using Management.Domain;

namespace Management.Infrastructure.Repositories.Interfaces
{
    public interface IAccountingDocumentRepository
    {
        Task<IEnumerable<AccountingDocument>> GetAllAsync();
        Task<AccountingDocument?> GetByIdAsync(int id);
        Task AddAsync(AccountingDocument document);
        Task UpdateAsync(AccountingDocument document);
        Task DeleteAsync(int id);
    }

}
