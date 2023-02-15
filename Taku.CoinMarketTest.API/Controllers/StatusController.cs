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
    public class BankController : ControllerBase
    {

        private readonly Mediator _mediator;
        public BankController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddStatus")]
        public IActionResult Create([FromBody] AddCommand command)
        {
            try
            {
                command.StatusId = Guid.NewGuid();
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = true, ex.Message });
            }
        }

        [HttpGet("GetStatus")]
        public IActionResult GetStatus(Guid statusId)
        {
            var result = _mediator.Dispatch(new GetStatusByStatusIdQuery { StatusId = statusId });
            return Ok(result);
        }

      
    }
}
