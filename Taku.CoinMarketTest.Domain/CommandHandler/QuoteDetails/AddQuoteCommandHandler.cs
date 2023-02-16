using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Domain.CommandHandler.QuoteDetails
{
    public class AddQuoteCommand : IRequest
    {
        public Guid QuoteId { get; set; }
        public Guid CryptoCoinId { get; set; }
        public string? Currency { get; set; }
    }

    public class AddQuoteCommandHandler : IRequestHandler<AddQuoteCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Quote> _repo;

        public AddQuoteCommandHandler(IUnitOfWork uow, IRepository<Quote> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddQuoteCommand command)
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
