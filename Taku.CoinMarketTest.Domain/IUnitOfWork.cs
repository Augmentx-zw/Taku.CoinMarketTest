namespace Taku.CoinMarketTest.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
