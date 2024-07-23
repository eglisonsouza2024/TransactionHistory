namespace TransactionHistory.Core.Results
{
    public class PageResult<T> where T : class
    {
        public IEnumerable<T>? Items { get; set; }
        public int TotalResults { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public void SetTotalPages()
        {
            TotalPages = TotalResults / PageSize;
        }

        public void SetHasNextPage()
        {
            HasNextPage = TotalPages > PageIndex;
        }

        public void SetHasPreviousPage()
        {
            HasPreviousPage = PageIndex > 1;
        }
    }
}
