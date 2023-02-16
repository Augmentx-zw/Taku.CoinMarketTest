namespace Taku.CoinMarketTest.Domain.Services
{
    public interface IHttpService
    {
        Task<string> GetAsync(string request, List<KeyValuePair<string, string>> additionalHeaders = null);
    }

    public sealed class HttpService : IHttpService
    {
        readonly IHttpClientFactory _clientFactory;

        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetAsync(string request, List<KeyValuePair<string, string>> additionalHeaders = null)
        {
            var client = _clientFactory.CreateClient();
            if (additionalHeaders != null)
            {
                foreach (var header in additionalHeaders)
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            var response = await client.GetAsync(request);
            var bodyContent = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return bodyContent;
            }

            throw new Exception(bodyContent);
        }

    }
}

