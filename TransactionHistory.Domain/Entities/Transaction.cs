using TransactionHistory.Core.DomainObjects;
using TransactionHistory.Domain.Enums;

namespace TransactionHistory.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public Account Account { get; private set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }

        public Transaction()
        {
        }

        public Transaction(Account account, decimal amount, DateTime transactionDate, TransactionType transactionType)
        {
            Account = account;
            AccountId = account.Id;
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
        }

    }
}
