using MediatR;
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
    public class StatusController : ControllerBase
    {

        private readonly IMediator _mediator;
        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetStatus")]
        public IActionResult GetStatus(Guid statusId)
        {
            var result = _mediator.Send(new GetExchangeRateQuery { StatusId = statusId });
            return Ok(result);
        }

      
    }
}
