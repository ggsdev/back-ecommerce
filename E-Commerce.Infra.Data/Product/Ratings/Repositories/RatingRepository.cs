using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Product.Ratings.Interfaces;

namespace E_Commerce.Infra.Data.Product.Ratings.Repositories
{
    internal class RatingRepository(DataContext context) : BaseRepository<Rating>(context), IRatingRepository
    {
    }
}
