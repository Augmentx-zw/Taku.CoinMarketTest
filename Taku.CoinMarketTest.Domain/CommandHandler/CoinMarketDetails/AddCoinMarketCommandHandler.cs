using Newtonsoft.Json;
using Taku.CoinMarketTest.API.Services;
using Taku.CoinMarketTest.Data.Models;
using Taku.CoinMarketTest.Domain.CommandHandler.CryptoCoinDetails;
using Taku.CoinMarketTest.Domain.CommandHandler.CurrencyDetails;
using Taku.CoinMarketTest.Domain.CommandHandler.QuoteDetails;
using Taku.CoinMarketTest.Domain.CommandHandler.StatusDetails;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;

namespace Taku.CoinMarketTest.Domain.CommandHandler.CoinMarketDetails
{
    public class AddCoinMarketCommand : ICommand
    {
        public string? IntegrationKey { get; set; }
    }
    public class AddCoinMarketCommandHandler : ICommandHandler<AddCoinMarketCommand>
    {
        private readonly IGetCoinData _getCoin;

        public AddCoinMarketCommandHandler(IGetCoinData getCoin)
        {
            _getCoin = getCoin;
        }
        public void Handle(AddCoinMarketCommand command)
        {
            CoinClassDto coinDto = new ();
            string? res = _getCoin.GetCoinRequest(command.IntegrationKey);
            var obj = JsonConvert.DeserializeObject<CoinClassDto>(res);
            var statusCommand = new AddStatusCommand()
            {
                StatusId = Guid.NewGuid(),
                Credit_count = obj.Status.Credit_count,
                Elapsed= obj.Status.Elapsed,
                Error_code= obj.Status.Error_code,
                Error_message= obj.Status.Error_message,
                Notice= obj.Status.Notice,
                Timestamp= obj.Status.Timestamp
            };

            // add status(statusCommand)

            var cryptoCoinCommandList = new List<AddCryptoCoinCommand>();

            foreach (var item in obj.Coin)
            {
                var cryptoCoinCommand = new AddCryptoCoinCommand
                {
                    CryptoCoinId = Guid.NewGuid(),
                    StatusId = statusCommand.StatusId,
                    Date_added = item.Date_added,
                    Circulating_supply= item.Circulating_supply,
                    Cmc_rank= item.Cmc_rank,
                    Tags= string.Join(",", item.CoinTags),
                    Id = item.Id,
                    Last_updated= item.Last_updated,
                    Max_supply= item.Max_supply,
                    Name= item.Name,
                    Num_market_pairs= item.Num_market_pairs,
                    Platform= item.Platform,
                    Self_reported_circulating_supply = item.Self_reported_circulating_supply,
                    Self_reported_market_cap    = item.Self_reported_market_cap,
                    Slug = item.Slug,
                    Symbol= item.Symbol,
                    Total_supply= item.Total_supply
                };
                cryptoCoinCommandList.Add(cryptoCoinCommand);

                var quoteCommand = new AddQuoteCommand
                {
                    QuoteId = Guid.NewGuid(),
                    CryptoCoinId = cryptoCoinCommand.CryptoCoinId,
                    Currency = "USD"
                };

                var currencyCommand = new AddCurrencyCommand
                {
                    QuoteId = quoteCommand.QuoteId,
                    CurrencyId = Guid.NewGuid(),
                    Fully_diluted_market_cap = item.Quote.USD.Fully_diluted_market_cap,
                    Last_updated = item.Quote.USD.Last_updated,
                    Market_cap =  item.Quote.USD.Market_cap,
                    Market_cap_dominance = item.Quote.USD.Market_cap_dominance,
                    Percent_change_1h = item.Quote.USD.Percent_change_1h,
                    Percent_change_24h = item.Quote.USD.Percent_change_24h,
                    Percent_change_7d = item.Quote.USD.Percent_change_7d,
                    Price= item.Quote.USD.Price,
                    Volume_24h = item.Quote.USD.Volume_24h,
                    Volume_change_24h = item.Quote.USD.Volume_change_24h
                };
            }

            // save everything
        }
    }
}
