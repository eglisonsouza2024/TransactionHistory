using MediatR;
using TransactionHistory.Core.Results;

namespace TransactionHistory.Core.Mediator.Messages
{
    public abstract class Command : IRequest<CustomResult>
    {
    }
}
