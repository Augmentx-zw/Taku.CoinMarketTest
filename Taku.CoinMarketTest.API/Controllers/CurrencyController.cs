using Microsoft.AspNetCore.Mvc;
using System;
using Taku.CoinMarketTest.API;
using Taku.CoinMarketTest.Data.Models;
using Taku.CoinMarketTest.Domain.CommandHandler.CurrencyDetails;
using Taku.CoinMarketTest.Domain.QueryHandlers.CurrencyDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly Mediator _mediator;
        public CurrencyController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCurrenies")]
        public IActionResult GetCurrenies(Guid quoute)
        {
            var result = _mediator.Dispatch(new GetCurrenyByQuoteIdQuery { QuoteId = quoute });
            return Ok(result);
        }

      
    }
}
