using TransactionHistory.Application.Messages.Extracts.Models.Enums;
using TransactionHistory.Core.Mediator.Messages;

namespace TransactionHistory.Application.Messages.Extracts.Queries
{
    public sealed class GetExtractQuery : Command
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public FilterExtract DateFilter { get; set; }
        public Guid AccountId { get; set; }


        public GetExtractQuery(FilterExtract dateFilter, Guid accountId, int size = 10, int index = 0)
        {
            Size = size;
            Index = index;
            DateFilter = dateFilter;
            AccountId = accountId;
        }

        public DateTime GetDayFilter()
        {
            return DateFilter switch
            {
                FilterExtract.FiveDays => DateTime.Now.AddDays(-5),
                FilterExtract.TenDays => DateTime.Now.AddDays(-10),
                FilterExtract.FifteenDays => DateTime.Now.AddDays(-15),
                FilterExtract.TwentyDays => DateTime.Now.AddDays(-20),
                _ => DateTime.Now,
            };
        }
    }
}
