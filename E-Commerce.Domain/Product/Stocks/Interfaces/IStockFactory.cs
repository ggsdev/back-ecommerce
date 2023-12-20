using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Stocks.Interfaces
{
    public interface IStockFactory
    {
        Stock Create(CreateUpdateStockViewModel createUpdateStockViewModel);
        Stock Update(CreateUpdateStockViewModel createUpdateStockViewModel, Stock stock);
    }
}
