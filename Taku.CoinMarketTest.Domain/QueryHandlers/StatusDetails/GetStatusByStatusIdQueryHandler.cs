using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.StatusDetails
{
    public class GetStatusByStatusIdQuery : IQuery<IEnumerable<Status>>
    {
        public Guid StatusId { get; set; }
    }

    public class GetStatusByStatusIdQueryHandler : IQueryHandler<GetStatusByStatusIdQuery, IEnumerable<Status>>
    {
        private readonly IRepository<Status> _repo;

        public GetStatusByStatusIdQueryHandler(IRepository<Status> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Status> Handle(GetStatusByStatusIdQuery query)
        {
            var res = _repo.Get(p => p.StatusId == query.StatusId);
            return res;
        }
    }
}
