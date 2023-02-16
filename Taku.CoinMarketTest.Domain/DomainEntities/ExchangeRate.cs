using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Domain.DomainEntities
{
    public class ExchangeRate
    {
        [Key]
        public Guid ExchangeRateId { get; set; }
        public string ExchangeRateResponce { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
