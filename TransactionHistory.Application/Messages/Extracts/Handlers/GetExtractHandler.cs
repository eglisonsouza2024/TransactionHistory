using MediatR;
using TransactionHistory.Application.Messages.Extracts.Models;
using TransactionHistory.Application.Messages.Extracts.Models.Enums;
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
            var result = await _repository.GetAllAsync(request.Size, request.Index, GetDayBase(request.DateFilter), request.AccountId, cancellationToken);

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

            return CustomResult.Success(pageResult);
        }

        private DateTime GetDayBase(FilterExtract dateFilter)
        {
            return dateFilter switch
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
