using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Stocks.Interfaces
{
    public interface IStockService
    {
        Task<Stock> CreateStock(CreateUpdateStockViewModel createUpdateStockViewModel);
        //Stock UpdateStock(CreateUpdateStockViewModel createUpdateStockViewModel, long id);
        //StockDto GetStock(long id);
        //void DeleteStock(long id);
        //PaginatedDataDTO<StockDto> GetAllStocks();
    }
}
