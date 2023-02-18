using MediatR;
using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails
{
    public class GetExchangeRatesQuery : IRequest<IEnumerable<ExchangeRate>>
    {
    }

    public class GetExchangeRatesQueryHandler : IRequestHandler<GetExchangeRatesQuery, IEnumerable<ExchangeRate>>
    {
        private readonly IRepository<ExchangeRate> _repo;

        public GetExchangeRatesQueryHandler(IRepository<ExchangeRate> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ExchangeRate>> Handle(GetExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync();
        }
    }
}
