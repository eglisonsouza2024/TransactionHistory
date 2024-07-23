namespace TransactionHistory.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
