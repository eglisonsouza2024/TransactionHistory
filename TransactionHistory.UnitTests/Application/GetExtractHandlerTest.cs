using NSubstitute;
using TransactionHistory.Application.Messages.Extracts.Handlers;
using TransactionHistory.Application.Messages.Extracts.Models.Enums;
using TransactionHistory.Application.Messages.Extracts.Queries;
using TransactionHistory.Core.Results;
using TransactionHistory.Domain.Entities;
using TransactionHistory.Domain.Enums;
using TransactionHistory.Domain.Repository;
using TransactionHistory.Domain.Repository.Args;

namespace TransactionHistory.UnitTests.Application
{
    public class GetExtractHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_Success_Result()
        {
            // Arrange
            var repository = Substitute.For<ITransactionRepository>();
            var handler = new GetExtractHandler(repository);

            var query = new GetExtractQuery(
                FilterExtract.TenDays,
                Guid.NewGuid(),
                10,
                0
            );

            var expectedResult = CustomResult.Success(BuildResult());

            repository.GetAllAsync(Arg.Any<GetExtractArgs>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(BuildResult()));

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult.IsSuccess, result.IsSuccess);
        }

        private static PageResult<Transaction> BuildResult()
        {
            var person = new Person("Rodrigo Souza");
            var account = new Account(person);

            var transactions = new List<Transaction>()
            {
                new Transaction(account, 100, DateTime.Now, TransactionType.Deposit),
                new Transaction(account, 90, DateTime.Now, TransactionType.Withdraw)
            };

            return new PageResultBuild<Transaction>()
                .BuildItems(transactions)
                .BuildTotalResults(transactions.Count)
                .BuildPageIndex(0)
                .BuildPageSize(10)
                .BuildTotalPages()
                .BuildHasNextPage()
                .BuildHasPreviousPage()
                .Build();
        }
    }
}
