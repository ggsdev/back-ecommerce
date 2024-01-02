using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Product.Ratings.Interfaces;
using E_Commerce.DTOs.ViewModels.Product;

namespace E_Commerce.Domain.Product.Ratings.Factories
{
    internal class RatingFactory : IRatingFactory
    {
        public Rating Create(CreateUpdateRatingViewModel createUpdateRatingViewModel)
        {
            return new Rating
            {
                Value = createUpdateRatingViewModel.Value!.Value,
                Comment = createUpdateRatingViewModel.Comment,
                ItemId = createUpdateRatingViewModel.ItemId!.Value,
                UserId = createUpdateRatingViewModel.UserId!.Value,
            };
        }

        public Rating Update(CreateUpdateRatingViewModel createUpdateRatingViewModel, Rating rating)
        {
            rating.Value = createUpdateRatingViewModel.Value!.Value;
            rating.Comment = createUpdateRatingViewModel.Comment;
            rating.ItemId = createUpdateRatingViewModel.ItemId!.Value;
            rating.UserId = createUpdateRatingViewModel.UserId!.Value;

            return rating;
        }
    }
}
