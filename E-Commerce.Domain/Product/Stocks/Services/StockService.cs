using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.Stocks.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Stocks.Services
{
    internal class StockService(IStockFactory factory, IStockRepository stockRepository) : IStockService
    {
        private readonly IStockFactory _factory = factory;
        private readonly IStockRepository _repository = stockRepository;

        public async Task<Stock> CreateStock(CreateUpdateStockViewModel createUpdateStockViewModel)
        {
            var createdStock = _factory.Create(createUpdateStockViewModel);

            await _repository.Add(createdStock);

            return createdStock;
        }
    }
}
