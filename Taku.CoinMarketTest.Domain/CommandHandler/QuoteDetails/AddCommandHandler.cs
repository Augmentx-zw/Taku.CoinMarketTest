using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.CommandHandler.QuoteDetails
{
    public class AddCommand : ICommand
    {
        public Guid QuoteId { get; set; }
        public Guid CryptoCoinId { get; set; }
        public string? Currency { get; set; }
    }

    public class AddCommandHandler : ICommandHandler<AddCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Quote> _repo;

        public AddCommandHandler(IUnitOfWork uow, IRepository<Quote> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddCommand command)
        {

            Quote InitQuote = new Quote
            {
                QuoteId = command.QuoteId,
                CryptoCoinId = command.CryptoCoinId,
                Currency = command.Currency
            };
            _repo.Insert(InitQuote);
            _uow.Save();
        }

    }
}
