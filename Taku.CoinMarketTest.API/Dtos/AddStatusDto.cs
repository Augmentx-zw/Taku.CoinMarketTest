namespace Taku.CoinMarketTest.API.Dtos
{
    public class AddStatusDto
    {
        public DateTime Timestamp { get; set; }
        public int Error_code { get; set; }
        public string? Error_message { get; set; }
        public int Elapsed { get; set; }
        public int Credit_count { get; set; }
        public string? Notice { get; set; }
    }
}
