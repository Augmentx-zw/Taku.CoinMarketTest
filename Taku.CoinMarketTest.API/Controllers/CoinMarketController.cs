using MediatR;
using Microsoft.AspNetCore.Authorization;
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


    }
}
