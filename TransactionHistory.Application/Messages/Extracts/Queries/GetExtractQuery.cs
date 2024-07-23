using TransactionHistory.Core.Mediator.Messages;

namespace TransactionHistory.Application.Messages.Extracts.Queries
{
    public class GetExtractQuery : Command
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public DateTime DateFilter { get; set; }
        public Guid AccountId { get; set; }


        public GetExtractQuery(DateTime dateFilter, Guid accountId, int size = 10, int index = 0)
        {
            Size = size;
            Index = index;
            DateFilter = dateFilter;
            AccountId = accountId;
        }

        private void Validate()
        {
            if (Size < 0)
            {

            }

            if (Index < 0)
            {

            }
        }
    }
}
