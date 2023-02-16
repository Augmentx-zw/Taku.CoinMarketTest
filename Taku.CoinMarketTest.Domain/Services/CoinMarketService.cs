using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Web;
using Taku.CoinMarketTest.Domain.Configurations;
using Taku.CoinMarketTest.Domain.DomainEntities;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;

namespace Taku.CoinMarketTest.Domain.Services
{
    public interface ICoinMarketService
    {
        Task<CoinClassDto> GetCoinRequestAsync(string currency);
        Task AddCoinMarketDataAsync(CoinClassDto coinClassDto);
    }

    public class CoinMarketService : ICoinMarketService
    {
        private readonly string _apiKey;
        private readonly string _apiLimit;
        private readonly IHttpService _httpService;
        private readonly IRepository<ExchangeRate> _repository;
        private readonly IUnitOfWork _uow;

        public CoinMarketService(IOptions<AppConfigs> options, IHttpService httpService, IRepository<ExchangeRate> repository, IUnitOfWork uow)
        {
            _apiKey = options.Value.Key;
            _apiLimit = options.Value.Limit;
            _httpService = httpService;
            _repository = repository;
            _uow = uow;
        }

        public async Task<CoinClassDto> GetCoinRequestAsync(string currency)
        {

            var header = new List<KeyValuePair<string, string>>();
            header.Add(KeyValuePair.Create("X-CMC_PRO_API_KEY", _apiKey));
            header.Add(KeyValuePair.Create("Accepts", "application/json"));


            var Url = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = _apiLimit;
            queryString["convert"] = currency;

            Url.Query = queryString.ToString();

            var result = await _httpService.GetAsync(Url.ToString());
            var coinClassDto = JsonConvert.DeserializeObject<CoinClassDto>(result);

            return coinClassDto;
        }

        public async Task AddCoinMarketDataAsync(CoinClassDto coinClassDto)
        {
            var jsonString = JsonConvert.SerializeObject(coinClassDto);

            var exchangeRate = new ExchangeRate()
            {
                ExchangeRateId = Guid.NewGuid(),
                ExchangeRateResponce = jsonString,
                CreatedOn = DateTime.Now
            };

            await _repository.InsertAsync(exchangeRate);
            await _uow.SaveAsync();

        }
    }
}
