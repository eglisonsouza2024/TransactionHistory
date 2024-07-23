using MediatR;
using TransactionHistory.Application.Messages.Extracts.Models;
using TransactionHistory.Application.Messages.Extracts.Queries;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Repository;

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
            var result = await _repository.GetAllAsync(request.Size, request.Index, request.DateFilter, request.AccountId, cancellationToken);

            var pageResult = new PageResult<ExtractOutputModel>
            {
                Items = result.Items!.Select(x => new ExtractOutputModel(x.TransactionDate.ToString("dd/MM/yyyy"), x.TransactionType, x.Amount)),
                TotalResults = result.TotalResults,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage
            };

            return CustomResult.Success("", pageResult);
        }
    }
}
