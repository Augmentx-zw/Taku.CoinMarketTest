using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Taku.CoinMarketTest.Domain.QueryHandlers.ExchangeRateDetails;
using Taku.CoinMarketTest.Domain.DomainEntities;
using Taku.CoinMarketTest.Domain;

public class GetExchangeRateByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidExchangeRateId_ReturnsExchangeRate()
    {
        // Arrange
        var exchangeRateId = Guid.NewGuid();
        var exchangeRate = new ExchangeRate { ExchangeRateId = exchangeRateId };
        var repositoryMock = new Mock<IRepository<ExchangeRate>>();
        repositoryMock.Setup(repo => repo.GetByIDAsync(exchangeRateId)).ReturnsAsync(exchangeRate);
        var query = new GetExchangeRateByIdQuery { ExchangeRateId = exchangeRateId };
        var handler = new GetExchangeRateByIdQueryHandler(repositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(exchangeRate, result);
    }

    [Fact]
    public async Task Handle_InvalidExchangeRateId_ReturnsNull()
    {
        // Arrange
        var exchangeRateId = Guid.NewGuid();
        var repositoryMock = new Mock<IRepository<ExchangeRate>>();
        repositoryMock.Setup(repo => repo.GetByIDAsync(exchangeRateId)).ReturnsAsync(null as ExchangeRate);
        var query = new GetExchangeRateByIdQuery { ExchangeRateId = exchangeRateId };
        var handler = new GetExchangeRateByIdQueryHandler(repositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
