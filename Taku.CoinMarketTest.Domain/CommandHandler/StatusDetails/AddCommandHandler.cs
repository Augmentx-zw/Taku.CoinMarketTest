using Taku.CoinMarketTest.Data.Models;

namespace Taku.CoinMarketTest.Domain.CommandHandler.StatusDetails
{
    public class AddCommand : ICommand
    {
        public Guid StatusId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Error_code { get; set; }
        public string? Error_message { get; set; }
        public int Elapsed { get; set; }
        public int Credit_count { get; set; }
        public string? Notice { get; set; }
    }

    public class AddCommandHandler : ICommandHandler<AddCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Status> _repo;

        public AddCommandHandler(IUnitOfWork uow, IRepository<Status> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddCommand command)
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
            _repo.Insert(InitStatus);
            _uow.Save();
        }

    }
}
