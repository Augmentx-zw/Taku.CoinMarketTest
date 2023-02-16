using MediatR;
using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Domain.CommandHandler.StatusDetails
{
    public class AddStatusCommand : IRequest
    {
        public Guid StatusId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Error_code { get; set; }
        public string? Error_message { get; set; }
        public int Elapsed { get; set; }
        public int Credit_count { get; set; }
        public string? Notice { get; set; }
    }

    public class AddStatusCommandHandler : IRequestHandler<AddStatusCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Status> _repo;

        public AddStatusCommandHandler(IUnitOfWork uow, IRepository<Status> repo)
        {
            _uow = uow;
            _repo = repo;
        }

        public async Task Handle(AddStatusCommand command, CancellationToken cancellationToken)
        {
            Status InitStatus = new Status
            {
                StatusId = command.StatusId,
                Credit_count = command.Credit_count,
                Notice = command.Notice,
                Elapsed = command.Elapsed,
                Error_code = command.Error_code,
                Error_message = command.Error_message,
                Timestamp = command.Timestamp
            };
            await _repo.InsertAsync(InitStatus);
            await _uow.SaveAsync();
        }
    }
}
