using MediatR;
using TransactionHistory.Application.Messages.Extracts.Models;
using TransactionHistory.Application.Messages.Extracts.Queries;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;
using TransactionHistory.Domain.Repository;
using TransactionHistory.Domain.Repository.Args;

namespace TransactionHistory.Application.Messages.Extracts.Handlers
{
    public class GetExtractHandler : IRequestHandler<GetExtractQuery, CustomResult>
    {
        private readonly ITransactionRepository _repository;

        public GetExtractHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomResult> Handle(GetExtractQuery request, CancellationToken cancellationToken)
        {
            var extractArgs = BuildExtractArgs(request);

            var result = await _repository.GetAllAsync(extractArgs, cancellationToken);
            
            var pageResult = BuildPageResult(result);

            return CustomResult.Success(pageResult);
        }

        private static PageResult<ExtractOutputModel> BuildPageResult(PageResult<Transaction> result)
        {
            return new PageResultBuild<ExtractOutputModel>()
                .BuildItems(result.Items!.Select(x => new ExtractOutputModel(x.TransactionDate.ToString("dd/MM"), x.TransactionType, x.Amount)))
                .BuildTotalResults(result.TotalResults)
                .BuildPageIndex(result.PageIndex)
                .BuildPageSize(result.PageSize)
                .BuildTotalPages()
                .BuildHasNextPage()
                .BuildHasPreviousPage()
                .Build();
        }

        private static GetExtractArgs BuildExtractArgs(GetExtractQuery request)
        {
            return new GetExtractArgsBuild()
                .BuildIndex(request.Index)
                .BuildSize(request.Size)
                .BuildAccountId(request.AccountId)
                .BuildDateFilter(request.GetDayFilter())
                .Build();
        }

    }
}
