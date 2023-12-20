using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.Stocks.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Stocks.Factories
{
    internal class StockFactory : IStockFactory
    {
        public Stock Create(CreateUpdateStockViewModel createUpdateStockViewModel)
        {
            return new Stock
            {
                Quantity = createUpdateStockViewModel.Quantity,
                IsAvailable = createUpdateStockViewModel.IsAvailable,
            };
        }

        public Stock Update(CreateUpdateStockViewModel createUpdateStockViewModel, Stock stock)
        {
            stock.Quantity = createUpdateStockViewModel.Quantity;
            stock.IsAvailable = createUpdateStockViewModel.IsAvailable;

            return stock;
        }
    }
}
