using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Taku.CoinMarketTest.API.DTO;

namespace Taku.CoinMarketTest.API.Services
{
    public class GetCoinDataImplementation : IGetCoinData
    {

        private readonly string? key;

        public GetCoinDataImplementation(IConfiguration configuration)
        {
            key = configuration["Key"];
        }

        
        public string GetCoinRequest()
        {
            var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", key);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }
}
