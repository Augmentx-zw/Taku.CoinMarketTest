using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Data.Models
{
    public class CryptoCoin
    {
        [Key]
        public Guid CryptoCoinId { get; set; }
        public Guid StatusId { get; set; }
        public string? Name { get; set; }
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? Slug { get; set; }
        public int Cmc_rank { get; set; }
        public int Num_market_pairs { get; set; }
        public int Circulating_supply { get; set; }
        public int Total_supply { get; set; }
        public int Max_supply { get; set; }
        public string? Tags { get; set; }
        public string? ProcessedTags { get; set; }
        public string? CoinTags { get; set; }
        public string? Platform { get; set; }
        public string? Self_reported_circulating_supply { get; set; }
        public string? Self_reported_market_cap { get; set; }
        public DateTime Last_updated { get; set; }
        public DateTime Date_added { get; set; }
    }
}
