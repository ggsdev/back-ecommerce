using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Stocks.Interfaces
{
    public interface IStockService
    {
        Task<Stock> CreateStock(CreateUpdateStockViewModel createUpdateStockViewModel);
        Task UpdateStock(CreateUpdateStockViewModel createUpdateStockViewModel, int id);
        //StockDto GetStock(int id);
        //void DeleteStock(int id);
        //PaginatedDataDTO<StockDto> GetAllStocks();
    }
}
