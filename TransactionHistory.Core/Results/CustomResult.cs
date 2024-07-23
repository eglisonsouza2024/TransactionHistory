namespace TransactionHistory.Core.Results
{
    public class CustomResult
    {
        public bool IsSuccess { get; set; }
        public string[]? Errors { get; set; }
        public object? Data { get; set; }

        public static CustomResult Success(object? data = null)
        {
            return new CustomResult { IsSuccess = true, Data = data };
        }

        public static CustomResult Fail(string[]? errors = null)
        {
            return new CustomResult { IsSuccess = false, Errors = errors };
        }
    }
}
