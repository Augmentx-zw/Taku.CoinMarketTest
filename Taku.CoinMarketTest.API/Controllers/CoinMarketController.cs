using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;
using Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CoinMarketController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CoinMarketController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("GetCurrentCoinMarket")]
        public async Task<IActionResult> GetCurrentCoinMarketAsync(string currency)
        {
            CoinClassDto result = await _mediator.Send(new GetExchangeRateQuery { Currency = currency });
            return Ok(result);
        }

        [HttpGet("GetCoinMarketHistory")]
        public async Task<IActionResult> GetCoinMarketHistoryAsync()
        {
            var result = await _mediator.Send(new GetExchangeRatesQuery { });
            return Ok(result);
        }

        [HttpGet("GetCoinMarketById")]
        public async Task<IActionResult> GetCoinMarketByIdAsync(Guid coinId)
        {
            var result = await _mediator.Send(new GetExchangeRateByIdQuery {  ExchangeRateId = coinId });
            return Ok(result);
        }

    }
}
