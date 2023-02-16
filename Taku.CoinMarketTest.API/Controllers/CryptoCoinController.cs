using Microsoft.AspNetCore.Mvc;
using Taku.CoinMarketTest.Domain.CommandHandler.CryptoCoinDetails;
using Taku.CoinMarketTest.Domain.QueryHandlers.CryptoCoinDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCoinController : ControllerBase
    {

        private readonly Mediator _mediator;
        public CryptoCoinController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddStatus")]
        public IActionResult Create([FromBody] AddCommand command)
        {
            try
            {
                command.CryptoCoinId = Guid.NewGuid();
                command.StatusId = Guid.NewGuid();
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("GetStatus")]
        public IActionResult GetStatus(Guid statusId)
        {
            var result = _mediator.Dispatch(new GetCryptoCoinByStatusIdQuery { StatusId = statusId });
            return Ok(result);
        }


    }
}
