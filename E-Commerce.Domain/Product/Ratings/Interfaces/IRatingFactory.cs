using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Ratings.Interfaces
{
    public interface IRatingFactory
    {
        Rating Create(CreateUpdateRatingViewModel createUpdateRatingViewModel);
        Rating Update(CreateUpdateRatingViewModel createUpdateRatingViewModel, Rating rating);
    }
}