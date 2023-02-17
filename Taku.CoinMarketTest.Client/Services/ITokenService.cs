using IdentityModel.Client;

namespace Taku.CoinMarketTest.Client.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}