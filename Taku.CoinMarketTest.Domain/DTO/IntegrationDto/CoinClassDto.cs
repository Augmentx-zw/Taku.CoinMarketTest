using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Domain.DTO.IntegrationDto
{

    public class CoinClassDto
    {
        [Key]
        public int Id { get; set; }
        public Status? Status { get; set; }
        public List<Coin>? Coin { get; set; }
    }
    public class Coin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Slug { get; set; }
        public int Cmc_rank { get; set; }
        public int Num_market_pairs { get; set; }
        public int Circulating_supply { get; set; }
        public int Total_supply { get; set; }
        public int Max_supply { get; set; }
        public DateTime Last_updated { get; set; }
        public DateTime Date_added { get; set; }
        public string[]? Tags { get; set; }
        public string? CoinTags { get; set; }
        public string? Platform { get; set; }
        public string? Self_reported_circulating_supply { get; set; }
        public string? Self_reported_market_cap { get; set; }
        public Quote? Quote { get; set; }
    }

    public class Quote
    {
        public int Id { get; set; }
        public USD? USD { get; set; }
    }



    public class Status
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int Error_code { get; set; }
        public string? Error_message { get; set; }
        public int Elapsed { get; set; }
        public int Credit_count { get; set; }
        public string? Notice { get; set; }
    }

    public class USD
    {
        public int Id { get; set; }
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
