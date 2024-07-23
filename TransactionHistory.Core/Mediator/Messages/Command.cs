using MediatR;
using TransactionHistory.Core.Results;

namespace TransactionHistory.Core.Mediator.Messages
{
    public class Command : IRequest<CustomResult>
    {
    }
}
