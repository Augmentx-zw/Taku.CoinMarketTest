using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Domain.DomainEntities
{
    public class CoinExchangeHistory
    {
        [Key]
        public Guid CoinExchangeHistoryId { get; set; }
        public string? ExchangeHistory { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
