namespace TransactionHistory.Domain.Repository.Args
{
    public sealed class GetExtractArgsBuild
    {
        private readonly GetExtractArgs _getExtractArgs = new();

        public GetExtractArgsBuild BuildSize(int size)
        {
            _getExtractArgs.Size = size;
            return this;
        }

        public GetExtractArgsBuild BuildIndex(int index)
        {
            _getExtractArgs.Index = index;
            return this;
        }

        public GetExtractArgsBuild BuildDateFilter(DateTime dateFilter)
        {
            _getExtractArgs.DateFilter = dateFilter;
            return this;
        }

        public GetExtractArgsBuild BuildAccountId(Guid accountId)
        {
            _getExtractArgs.AccountId = accountId;
            return this;
        }

        public GetExtractArgs Build() => _getExtractArgs;
    }
}
