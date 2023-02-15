using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.CurrencyDetails
{
    public class GetCurrenyByQuoteIdQuery : IQuery<IEnumerable<Currency>>
    {
        public Guid QuoteId { get; set; }
    }

    public class GetCurrenyByQuoteIdQueryHandler : IQueryHandler<GetCurrenyByQuoteIdQuery, IEnumerable<Currency>>
    {
        private readonly IRepository<Currency> _repo;

        public GetCurrenyByQuoteIdQueryHandler(IRepository<Currency> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Currency> Handle(GetCurrenyByQuoteIdQuery query)
        {
            var res = _repo.Get(p => p.QuoteId == query.QuoteId);
            return res;
        }
    }
}
