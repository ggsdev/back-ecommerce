using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.Stocks.Interfaces;

namespace E_Commerce.Infra.Data.Product.Stocks.Repositories
{
    internal class StockRepository(DataContext context) : BaseRepository<Stock>(context), IStockRepository
    {

    }
}
