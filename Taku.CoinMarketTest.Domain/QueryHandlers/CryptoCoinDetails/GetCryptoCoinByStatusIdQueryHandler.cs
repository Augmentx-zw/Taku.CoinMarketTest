using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.CryptoCoinDetails
{
    public class GetCryptoCoinByStatusIdQuery : IQuery<IEnumerable<CryptoCoin>>
    {
        public Guid StatusId { get; set; }
    }

    public class GetCryptoCoinByStatusIdQueryHandler : IQueryHandler<GetCryptoCoinByStatusIdQuery, IEnumerable<CryptoCoin>>
    {
        private readonly IRepository<CryptoCoin> _repo;

        public GetCryptoCoinByStatusIdQueryHandler(IRepository<CryptoCoin> repo)
        {
            _repo = repo;
        }
        public IEnumerable<CryptoCoin> Handle(GetCryptoCoinByStatusIdQuery query)
        {
            var res = _repo.Get(p => p.StatusId == query.StatusId);
            return res;
        }
    }



}
