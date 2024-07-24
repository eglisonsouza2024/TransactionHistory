namespace TransactionHistory.Domain.Repository.Args
{
    public sealed class GetExtractArgs
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public DateTime DateFilter { get; set; }
        public Guid AccountId { get; set; }

        public int GetSkip()
        {
            return (Index - 1) * Size;
        }
    }
}
