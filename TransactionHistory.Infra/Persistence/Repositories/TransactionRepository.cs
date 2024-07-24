using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TransactionHistory.Core.Data;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;
using TransactionHistory.Domain.Repository;
using TransactionHistory.Domain.Repository.Args;

namespace TransactionHistory.Infra.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public sealed class TransactionRepository : ITransactionRepository
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

        public async Task<PageResult<Transaction>> GetAllAsync(GetExtractArgs getExtractArgs, CancellationToken cancellationToken)
        {
            var transactions = _dbContext.Transaction
                .Where(x => x.AccountId.Equals(getExtractArgs.AccountId) && x.TransactionDate >= getExtractArgs.DateFilter)
                .OrderByDescending(x => x.TransactionDate);

            var count = await transactions.CountAsync(cancellationToken);

            var result = transactions
                .AsNoTracking()
                .Skip(getExtractArgs.GetSkip())
                .Take(getExtractArgs.Size);

            return new PageResultBuild<Transaction>()
                .BuildItems(result)
                .BuildTotalResults(count)
                .BuildPageIndex(getExtractArgs.Index)
                .BuildPageSize(getExtractArgs.Size)
                .BuildTotalPages()
                .BuildHasNextPage()
                .BuildHasPreviousPage()
                .Build();
        }
    }
}
