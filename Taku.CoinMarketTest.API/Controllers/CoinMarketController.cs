using Microsoft.AspNetCore.Mvc;
using System;
using Taku.CoinMarketTest.API;
using Taku.CoinMarketTest.Data.Models;
using Taku.CoinMarketTest.Domain.CommandHandler.StatusDetails;
using Taku.CoinMarketTest.Domain.QueryHandlers.StatusDetails;

namespace Taku.CoinMarketTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinMarketController : ControllerBase
    {

        private readonly Mediator _mediator;
        public CoinMarketController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStatus")]
        public IActionResult GetMarketData(Guid statusId)
        {
            var result = _mediator.Dispatch(new GetStatusByStatusIdQuery { StatusId = statusId });
            return Ok(result);
        }

      
    }
}
