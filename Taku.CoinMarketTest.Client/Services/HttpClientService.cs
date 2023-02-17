using Newtonsoft.Json;
using System.Text;

namespace Taku.CoinMarketTest.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly string? baseUrl;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HttpClientService> _log;
        public HttpClientService(IHttpClientFactory clientFactory, IConfiguration configuration, ILogger<HttpClientService> log)
        {
            _clientFactory = clientFactory;
            baseUrl = configuration["ApiUrl"];
            _log = log;
        }

        public async Task<HttpResponseMessage> PostRequest<T>(T command, string actionUrl) where T : class
        {
            string postUrl = $"{baseUrl}/{actionUrl}";
            _log.LogInformation("Post request {0}", postUrl);

            HttpClient client = _clientFactory.CreateClient();
            StringContent postContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(postUrl, postContent);

            _log.LogInformation("Post Request {0} done", postUrl);
            return result;
        }
        public async Task<T> GetRequest<T>(T contectResult, string contentUrl) where T : class
        {
            string getUrl = $"{baseUrl}/{contentUrl}";
            _log.LogInformation("Get request {0}", getUrl);

            HttpClient client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(getUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                try
                {
                    contectResult = JsonConvert.DeserializeObject<T>(content);
                    _log.LogInformation("Get request {0} done", getUrl);

                }
                catch (Exception ex)
                {
                    _log.LogInformation("Error {0} logged", ex);
                }
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();

                throw new Exception(content);
            }
            return contectResult;
        }
    }
}
