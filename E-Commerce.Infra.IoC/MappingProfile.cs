using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.Ratings.Entities;
using E_Commerce.Domain.Product.Stocks.Entities;
using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.DTOs.DTOs;

namespace E_Commerce.Infra.IoC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Info, InfoDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Address, AddressDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Item, ItemDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Session, SessionDto>()
                .ForMember(x => x.ExpirationDate, x => x.MapFrom(y => y.ExpirationDate.ToString("dd/MM/yyyy HH:mm:ss")));

            CreateMap<Stock, StockDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));

            CreateMap<Rating, RatingDto>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(y => y.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(y => y.UpdatedAt != null ? y.UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm:ss") : null));
        }
    }
}
