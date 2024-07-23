using Microsoft.EntityFrameworkCore;
using TransactionHistory.Core.Data;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;
using TransactionHistory.Domain.Repository;

namespace TransactionHistory.Infra.Persistence.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionHistoryDbContext _dbContext;

        public TransactionRepository(TransactionHistoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<PageResult<Transaction>> GetAllAsync(int size, int index, DateTime dateFilter, Guid accountId, CancellationToken cancellationToken)
        {
            var transactions = _dbContext.Transaction
                .Where(x => x.AccountId.Equals(accountId) && x.TransactionDate >= dateFilter);

            var count = await transactions.CountAsync(cancellationToken);

            var result = transactions
                .AsNoTracking()
                .Skip(index)
                .Take(size);

            return new PageResult<Transaction>
            {
                Items = result,
                TotalResults = count,
                PageIndex = index,
                PageSize = size,
                TotalPages = count / size,
                HasNextPage = count / size > index,
                HasPreviousPage = index > 1,
            };
        }
    }
}
