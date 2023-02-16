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

        [HttpGet("CryptoCoins")]
        public IActionResult CryptoCoins(Guid statusId)
        {
            var result = _mediator.Dispatch(new GetCryptoCoinByStatusIdQuery { StatusId = statusId });
            return Ok(result);
        }


    }
}
