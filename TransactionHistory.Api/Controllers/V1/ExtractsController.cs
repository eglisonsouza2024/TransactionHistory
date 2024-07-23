using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransactionHistory.Application.Messages.Extracts.Queries;
using TransactionHistory.Core.Mediator.Handler;
using TransactionHistory.Core.Results;

namespace TransactionHistory.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/extracts")]
    public class ExtractsController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public ExtractsController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(DateTime dateFilter, Guid accountId, int size = 10, int index = 0)
        {
            var result = await _mediator.SendCommand(new GetExtractQuery(dateFilter, accountId, size, index));

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
