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

        [HttpPost("AddCurrency")]
        public IActionResult Create([FromBody] AddCommand command)
        {
            try
            {
                command.CurrencyId = Guid.NewGuid();
                command.QuoteId = Guid.NewGuid(); // change here
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("GetStatus")]
        public IActionResult GetStatus(Guid quoute)
        {
            var result = _mediator.Dispatch(new GetCurrenyByQuoteIdQuery { QuoteId = quoute });
            return Ok(result);
        }

      
    }
}
