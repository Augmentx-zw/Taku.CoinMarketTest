using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, IHttpClientService client, ITokenService tokenService)
        {
            _logger = logger;
            _client = client;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {

            //var tokenResponse = await _tokenService.GetToken("CoinMarketTestApi.read");

            ////_client.SetBearerToken(tokenResponse.AccessToken);

            //var header = new List<KeyValuePair<string, string>>();
            //header.Add(KeyValuePair.Create("X-CMC_PRO_API_KEY", "tmpJwt"));

            //var currency = "USD";
            //var result = await _client.GetRequest(new CoinClassViewModel(), $"CoinMarket/GetCurrentCoinMarket?currency={currency}");

            //return View(result);

            using var client = new HttpClient();

            var token = await HttpContext.GetTokenAsync("access_token");
            client.SetBearerToken(token);
            var currency = "USD";
            var result = await client.GetAsync($"https://localhost:5445/api/CoinMarket/GetCurrentCoinMarket?currency={currency}");

            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var coinData = JsonConvert.DeserializeObject<CoinClassViewModel>(model);
                var coinRates = new List<CoinViewModel>();

                foreach (var coinItem in coinData.Data)
                {
                    var coinRate = new CoinViewModel
                    {
                        Name = coinItem.Name.ToLower(),
                        Slug = coinItem.Slug.ToLower(),
                        Symbol = coinItem.Symbol.ToLower(),
                        Currency = coinItem.Quote.Currency.Name,
                        Price = (decimal)coinItem.Quote.Currency.Price            
                    };
                   
                    coinRates.Add(coinRate);
                }

                return View(coinRates);
            }

            throw new Exception("Unable to get content");

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