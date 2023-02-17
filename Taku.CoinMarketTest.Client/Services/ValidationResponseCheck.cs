using Newtonsoft.Json;
using Taku.CoinMarketTest.Client.ViewModels;

namespace Taku.CoinMarketTest.Client.Services
{
    public class ValidationResponseCheck
    {
        public static ErrorCheckViewModel IsValidResponse(HttpResponseMessage response)
        {
            bool isError = false;
            string? message = "";
            if (response.IsSuccessStatusCode)
            {
                ErrorCheckViewModel? content = JsonConvert.DeserializeObject<ErrorCheckViewModel>(response.Content.ReadAsStringAsync().Result);
                if (content is not null && content.Error)
                {
                    message = content.Message;
                    isError = true;
                }
                else
                {
                    message = "Record has successfully been added.";
                }
            }
            return new ErrorCheckViewModel { Error = isError, Message = message };
        }
    }
}
