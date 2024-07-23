using TransactionHistory.Core.Data;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;

namespace TransactionHistory.Domain.Repository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<PageResult<Transaction>> GetAllAsync(int size, int index, DateTime dateFilter, Guid accountId, CancellationToken cancellationToken);
    }
}
