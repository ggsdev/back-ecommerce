using AutoMapper;
using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Sessions.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.Product.Categories.Entities;
using E_Commerce.Domain.Product.Items.Entities;
using E_Commerce.Domain.Product.SubCategories.Entities;
using E_Commerce.DTOs.DTOs;

namespace E_Commerce.Infra.IoC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Info, InfoDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<Session, SessionDto>();
        }
    }
}
