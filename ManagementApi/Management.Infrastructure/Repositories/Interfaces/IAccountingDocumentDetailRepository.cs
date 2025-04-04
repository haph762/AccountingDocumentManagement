using Management.Domain;

namespace Management.Infrastructure.Repositories.Interfaces
{
    public interface IAccountingDocumentDetailRepository
    {
        Task AddDetailAsync(AccountingDocumentDetail detail);
    }

}
