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
            if (createUpdateStockViewModel.IsAvailable && createUpdateStockViewModel.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            var createdStock = _factory.Create(createUpdateStockViewModel);

            await _repository.Add(createdStock);

            return createdStock;
        }

        public async Task UpdateStock(CreateUpdateStockViewModel createUpdateStockViewModel, long id)
        {
            var stock = await _repository.GetByIdClean(id)
                ?? throw new Exception("Not found");

            if (createUpdateStockViewModel.IsAvailable && createUpdateStockViewModel.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            var updatedStock = _factory.Update(createUpdateStockViewModel, stock);

            _repository.Update(updatedStock);
        }
    }
}
