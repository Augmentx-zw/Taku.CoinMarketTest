using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Domain.DomainEntities
{
    public class Quote
    {
        [Key]
        public Guid QuoteId { get; set; }
        public Guid CryptoCoinId { get; set; }
        public string? Currency { get; set; }
    }
}
