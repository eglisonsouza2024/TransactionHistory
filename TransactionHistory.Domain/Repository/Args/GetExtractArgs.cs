namespace TransactionHistory.Domain.Repository.Args
{
    public class GetExtractArgs
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public DateTime DateFilter { get; set; }
        public Guid AccountId { get; set; }
    }
}
