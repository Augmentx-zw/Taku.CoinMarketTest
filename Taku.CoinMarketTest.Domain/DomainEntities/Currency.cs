using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Domain.DomainEntities
{
    public class Currency
    {
        [Key]
        public Guid CurrencyId { get; set; }
        public Guid QuoteId { get; set; }
        public double Price { get; set; }
        public int Volume_24h { get; set; }
        public double Volume_change_24h { get; set; }
        public double Percent_change_1h { get; set; }
        public double Percent_change_24h { get; set; }
        public double Percent_change_7d { get; set; }
        public double Market_cap { get; set; }
        public int Market_cap_dominance { get; set; }
        public double Fully_diluted_market_cap { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
