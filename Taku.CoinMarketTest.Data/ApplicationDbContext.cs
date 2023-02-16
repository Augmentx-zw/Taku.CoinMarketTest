using Microsoft.EntityFrameworkCore;
using Taku.CoinMarketTest.Domain.DomainEntities;

namespace Taku.CoinMarketTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
