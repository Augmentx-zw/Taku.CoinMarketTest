using Microsoft.AspNetCore.Mvc;
using System;
using Taku.CoinMarketTest.API;
using Taku.CoinMarketTest.Data.Models;
using Taku.CoinMarketTest.Domain.CommandHandler.QuoteDetails;
using Taku.CoinMarketTest.Domain.QueryHandlers.QuoteDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {

        private readonly Mediator _mediator;
        public QuoteController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetQuote")]
        public IActionResult GetQuote(Guid coinId)
        {
            var result = _mediator.Dispatch(new GetQuoteByCryptoCoinIdQuery { CryptoCoinId = coinId });
            return Ok(result);
        }

      
    }
}
