using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Client.ViewModels
{
    public class ExchangeRateViewModel
    {
        [Key]
        public Guid ExchangeRateId { get; set; }
        public string ExchangeRateResponce { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
