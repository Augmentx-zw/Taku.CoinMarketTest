using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Domain.CommandHandler.CurrencyDetails
{
    public class AddCurrencyCommand : IRequest
    {
        public Guid CurrencyId { get; set; }
        public Guid QuoteId { get; set; }
        public double Price { get; set; }
        public int Volume_24h { get; set; }
        public double Volume_change_24h { get; set; }
        public double Percent_change_1h { get; set; }
        public double Percent_change_24h { get; set; }
        public double Percent_change_7d { get; set; }
        public double Market_cap { get; set; }
        public int Market_cap_dominance { get; set; }
        public double Fully_diluted_market_cap { get; set; }
        public DateTime Last_updated { get; set; }
    }
    public class AddCurrencyCommandHandler : IRequestHandler<AddCurrencyCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Currency> _repo;

        public AddCurrencyCommandHandler(IUnitOfWork uow, IRepository<Currency> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddCurrencyCommand command)
        {

            Currency InitCurrency = new Currency
            {
                CurrencyId = command.CurrencyId,
                QuoteId = command.QuoteId,
                Fully_diluted_market_cap = command.Fully_diluted_market_cap,
                Last_updated = command.Last_updated,
                Market_cap = command.Market_cap,
                Market_cap_dominance = command.Market_cap_dominance,
                Percent_change_1h = command.Percent_change_1h,
                Percent_change_24h = command.Percent_change_24h,
                Percent_change_7d = command.Percent_change_7d,
                Price = command.Price,
                Volume_24h = command.Volume_24h,
                Volume_change_24h = command.Volume_change_24h
            };
            _repo.Insert(InitCurrency);
            _uow.Save();
        }
    }
}
