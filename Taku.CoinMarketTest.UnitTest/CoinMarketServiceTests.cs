using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Taku.CoinMarketTest.Domain;
using Taku.CoinMarketTest.Domain.Configurations;
using Taku.CoinMarketTest.Domain.DomainEntities;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;
using Taku.CoinMarketTest.Domain.Services;

namespace Taku.CoinMarketTest.UnitTest
{
    public class CoinMarketServiceTests
    {
        private readonly Mock<IHttpService> _httpServiceMock;
        private readonly Mock<IRepository<ExchangeRate>> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CoinMarketServiceTests()
        {
            _httpServiceMock = new Mock<IHttpService>();
            _repositoryMock = new Mock<IRepository<ExchangeRate>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task GetCoinRequestAsync_Returns_CoinClassDto()
        {
            // Arrange
            var options = Options.Create(new AppConfigs
            {
                Key = "fakeApiKey",
                Limit = "100"
            });
            var service = new CoinMarketService(options, _httpServiceMock.Object, _repositoryMock.Object, _unitOfWorkMock.Object);

            var currency = "USD";
            var expected = new CoinClassDto();

            _httpServiceMock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<List<KeyValuePair<string, string>>>()))
                .ReturnsAsync(JsonConvert.SerializeObject(expected));

            // Act
            var actual = await service.GetCoinRequestAsync(currency);

            // Assert
            Assert.IsType<CoinClassDto>(actual);
        }

        [Fact]
        public async Task AddCoinMarketDataAsync_Stores_ExchangeRate()
        {
            // Arrange
            var service = new CoinMarketService(Options.Create(new AppConfigs()), _httpServiceMock.Object, _repositoryMock.Object, _unitOfWorkMock.Object);

            var coinClassDto = new CoinClassDto();
            var expected = new ExchangeRate();

            _repositoryMock.Setup(x => x.InsertAsync(It.IsAny<ExchangeRate>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);

            // Act
            await service.AddCoinMarketDataAsync(coinClassDto);

            // Assert
            _repositoryMock.Verify(x => x.InsertAsync(It.IsAny<ExchangeRate>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
