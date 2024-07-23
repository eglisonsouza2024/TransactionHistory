using TransactionHistory.Domain.Enums;

namespace TransactionHistory.Application.Messages.Extracts.Models.Outputs
{
    public sealed class ExtractOutputModel
    {
        public string TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }

        public ExtractOutputModel(string transactionDate, TransactionType transactionType, decimal amount)
        {
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            Amount = amount;
        }
    }
}
