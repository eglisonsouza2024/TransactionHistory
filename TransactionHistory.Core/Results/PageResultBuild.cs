namespace TransactionHistory.Core.Results
{
    public sealed class PageResultBuild<T> where T : class
    {
        private readonly PageResult<T> _pageResult = new();

        public PageResultBuild<T> BuildItems(IEnumerable<T> items)
        {
            _pageResult.Items = items;
            return this;
        }

        public PageResultBuild<T> BuildTotalResults(int totalResult)
        {
            _pageResult.TotalResults = totalResult;
            return this;
        }

        public PageResultBuild<T> BuildPageIndex(int pageIndex)
        {
            _pageResult.PageIndex = pageIndex;
            return this;
        }

        public PageResultBuild<T> BuildPageSize(int pageSize)
        {
            _pageResult.PageSize = pageSize;
            return this;
        }

        public PageResultBuild<T> BuildTotalPages()
        {
            _pageResult.SetTotalPages();
            return this;
        }

        public PageResultBuild<T> BuildHasNextPage()
        {
            _pageResult.SetHasNextPage();
            return this;
        }

        public PageResultBuild<T> BuildHasPreviousPage()
        {
            _pageResult.SetHasPreviousPage();
            return this;
        }

        public PageResult<T> Build() => _pageResult;
    }
}
