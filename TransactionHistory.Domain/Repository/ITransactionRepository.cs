using TransactionHistory.Core.Data;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;
using TransactionHistory.Domain.Repository.Args;

namespace TransactionHistory.Domain.Repository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<PageResult<Transaction>> GetAllAsync(GetExtractArgs getExtractArgs, CancellationToken cancellationToken);
    }
}
