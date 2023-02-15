using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.QuoteDetails
{
    public class GetQuoteByCryptoCoinIdQuery : IQuery<IEnumerable<Quote>>
    {
        public Guid CryptoCoinId { get; set; }
    }

    public class GetQuoteByCryptoCoinIdQueryHandler : IQueryHandler<GetQuoteByCryptoCoinIdQuery, IEnumerable<Quote>>
    {
        private readonly IRepository<Quote> _repo;

        public GetQuoteByCryptoCoinIdQueryHandler(IRepository<Quote> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Quote> Handle(GetQuoteByCryptoCoinIdQuery query)
        {
            var res = _repo.Get(p => p.CryptoCoinId == query.CryptoCoinId);
            return res;
        }
    }
}
