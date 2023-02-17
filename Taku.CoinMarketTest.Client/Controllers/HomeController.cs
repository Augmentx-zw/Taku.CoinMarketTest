using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Taku.CoinMarketTest.Client.Models;
using Taku.CoinMarketTest.Client.Services;
using Taku.CoinMarketTest.Client.ViewModels;

namespace Taku.CoinMarketTest.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientService _client;

        public HomeController(ILogger<HomeController> logger, IHttpClientService client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var header = new List<KeyValuePair<string, string>>();
            header.Add(KeyValuePair.Create("X-CMC_PRO_API_KEY", "tmpJwt"));

            var currency = "USD";
            var result = await _client.GetRequest(new CoinClassViewModel(), $"CoinMarket/GetCurrentCoinMarket?currency={currency}");

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}