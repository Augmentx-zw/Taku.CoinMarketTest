using System;

namespace Taku.CoinMarketTest.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
