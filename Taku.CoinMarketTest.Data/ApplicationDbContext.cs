using Microsoft.EntityFrameworkCore;
using Taku.CoinMarketTest.Data.Models;

namespace Ark.Gateway.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CryptoCoin> CryptoCoins { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        
    }
}
