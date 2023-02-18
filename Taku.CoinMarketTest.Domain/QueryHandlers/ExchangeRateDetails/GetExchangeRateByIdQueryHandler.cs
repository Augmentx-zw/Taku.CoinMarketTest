using MediatR;
using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails
{
    public class GetExchangeRateByIdQuery : IRequest<ExchangeRate>
    {
        public Guid ExchangeRateId { get; set; }
    }

    public class GetExchangeRateByIdQueryHandler : IRequestHandler<GetExchangeRateByIdQuery, ExchangeRate>
    {
        private readonly IRepository<ExchangeRate> _repo;

        public GetExchangeRateByIdQueryHandler(IRepository<ExchangeRate> repo)
        {
            _repo = repo;
        }


        public async Task<ExchangeRate> Handle(GetExchangeRateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIDAsync(request.ExchangeRateId);
        }
    }
}
