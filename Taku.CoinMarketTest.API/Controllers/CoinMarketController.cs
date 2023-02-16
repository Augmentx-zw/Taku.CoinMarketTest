using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinMarketController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CoinMarketController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("GetCurrentCoinMarket")]
        public IActionResult GetCurrentCoinMarket(string currency)
        {
            var result = _mediator.Send(new GetExchangeRateQuery { Currency = currency });
            return Ok(result);
        }


    }
}
