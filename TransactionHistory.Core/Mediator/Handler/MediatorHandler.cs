using MediatR;
using TransactionHistory.Core.Mediator.Messages;
using TransactionHistory.Core.Results;

namespace TransactionHistory.Core.Mediator.Handler
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CustomResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
