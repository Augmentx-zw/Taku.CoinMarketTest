using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.CommandHandler.CryptoCoinDetails
{
    public class AddCommand : ICommand
    {
        public Guid CryptoCoinId { get; set; }
        public Guid StatusId { get; set; }
        public string? Name { get; set; }
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? Slug { get; set; }
        public int Cmc_rank { get; set; }
        public int Num_market_pairs { get; set; }
        public int Circulating_supply { get; set; }
        public int Total_supply { get; set; }
        public int Max_supply { get; set; }
        public string? Tags { get; set; }
        public string? ProcessedTags { get; set; }
        public string? CoinTags { get; set; }
        public string? Platform { get; set; }
        public string? Self_reported_circulating_supply { get; set; }
        public string? Self_reported_market_cap { get; set; }
        public DateTime Last_updated { get; set; }
        public DateTime Date_added { get; set; }
    }
    public class AddCommandHandler : ICommandHandler<AddCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CryptoCoin> _repo;

        public AddCommandHandler(IUnitOfWork uow, IRepository<CryptoCoin> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddCommand command)
        {

            CryptoCoin InitCryptoCoin = new()
            {
               CryptoCoinId= command.CryptoCoinId,
               StatusId= command.StatusId,
               Date_added= command.Date_added,
               Circulating_supply= command.Circulating_supply,
               Cmc_rank= command.Cmc_rank,
               CoinTags= command.CoinTags,
               Platform= command.Platform,
               Id= command.Id,
               Last_updated= command.Last_updated,
               Max_supply= command.Max_supply,
               Name= command.Name,
               Num_market_pairs= command.Num_market_pairs,
               ProcessedTags= command.ProcessedTags,
               Self_reported_circulating_supply = command.Self_reported_circulating_supply,
               Self_reported_market_cap = command.Self_reported_market_cap,
               Slug= command.Slug,
               Symbol= command.Symbol,
               Tags= command.Tags,
               Total_supply= command.Total_supply
            };
            _repo.Insert(InitCryptoCoin);
            _uow.Save();
        }
    }
}
