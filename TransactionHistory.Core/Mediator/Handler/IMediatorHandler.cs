using TransactionHistory.Core.Mediator.Messages;
using TransactionHistory.Core.Results;

namespace TransactionHistory.Core.Mediator.Handler
{
    public interface IMediatorHandler
    {
        Task<CustomResult> SendCommand<T>(T command) where T : Command;
    }
}
