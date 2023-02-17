using Moq;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;
using Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails;
using Taku.CoinMarketTest.Domain.Services;

namespace Taku.CoinMarketTest.UnitTest
{
    public class GetExchangeRateQueryHandlerTests
    {
        [Fact]
        public async Task Handle_WithCurrency_ReturnsCoinClassDto()
        {
            // Arrange
            var expectedCoinClassDto = new CoinClassDto();
            var mockCoinMarketService = new Mock<ICoinMarketService>();
            mockCoinMarketService.Setup(x => x.GetCoinRequestAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedCoinClassDto);
            var query = new GetExchangeRateQuery { Currency = "USD" };
            var handler = new GetExchangeRateQueryHandler(mockCoinMarketService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedCoinClassDto, result);
        }

        [Fact]
        public async Task Handle_WithCurrency_CallsCoinMarketService()
        {
            // Arrange
            var mockCoinMarketService = new Mock<ICoinMarketService>();
            var query = new GetExchangeRateQuery { Currency = "USD" };
            var handler = new GetExchangeRateQueryHandler(mockCoinMarketService.Object);

            // Act
            await handler.Handle(query, CancellationToken.None);

            // Assert
            mockCoinMarketService.Verify(x => x.GetCoinRequestAsync(query.Currency), Times.Once);
            mockCoinMarketService.Verify(x => x.AddCoinMarketDataAsync(It.IsAny<CoinClassDto>()), Times.Once);
        }
    }
}
