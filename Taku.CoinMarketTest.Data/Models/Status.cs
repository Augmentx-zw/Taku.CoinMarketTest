using System.ComponentModel.DataAnnotations;

namespace Taku.CoinMarketTest.Data.Models
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Error_code { get; set; }
        public string? Error_message { get; set; }
        public int Elapsed { get; set; }
        public int Credit_count { get; set; }
        public string? Notice { get; set; }
    }
}
