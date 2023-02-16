﻿using MediatR;
using Taku.CoinMarketTest.Domain.DTO.IntegrationDto;
using Taku.CoinMarketTest.Domain.Services;

namespace Taku.CoinMarketTest.Domain.QueryHandlers.StatusDetails
{
    public class GetExchangeRateQuery : IRequest<CoinClassDto>
    {
        public string Currency { get; set; }
    }

    public class GetStatusByStatusIdQueryHandler : IRequestHandler<GetExchangeRateQuery, CoinClassDto>
    {
        private readonly ICoinMarketService _coinMarketService;

        public GetStatusByStatusIdQueryHandler(ICoinMarketService coinMarketService)
        {
            _coinMarketService = coinMarketService;
        }


        public async Task<CoinClassDto> Handle(GetExchangeRateQuery query, CancellationToken cancellationToken)
        {
            var coinClassDto = await _coinMarketService.GetCoinRequestAsync(query.Currency);
            _coinMarketService.AddCoinMarketData(coinClassDto);
            return coinClassDto;
        }
    }
}
