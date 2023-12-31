﻿using E_Commerce.Domain.ControlAccess.Infos.Factories;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Infos.Services;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Sessions.Services;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Factories;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Services;
using E_Commerce.Domain.ControlAccess.Users.Validators;
using E_Commerce.Domain.Product.Categories.Factories;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.Domain.Product.Categories.Services;
using E_Commerce.Domain.Product.Images.Factories;
using E_Commerce.Domain.Product.Images.Interfaces;
using E_Commerce.Domain.Product.Images.Services;
using E_Commerce.Domain.Product.Items.Factories;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Domain.Product.Items.Services;
using E_Commerce.Domain.Product.Ratings.Factories;
using E_Commerce.Domain.Product.Ratings.Interfaces;
using E_Commerce.Domain.Product.Ratings.Services;
using E_Commerce.Domain.Product.Stocks.Factories;
using E_Commerce.Domain.Product.Stocks.Interfaces;
using E_Commerce.Domain.Product.Stocks.Services;
using E_Commerce.Domain.Purcharse.Orders.Entities;
using E_Commerce.Domain.Purcharse.Orders.Validators;
using E_Commerce.DTOs.Validators;
using E_Commerce.DTOs.ViewModels.Product;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Domain
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterFactories(services);
            RegisterValidators(services);
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInfoService, InfoService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IRatingService, RatingService>();
        }

        public static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IInfoFactory, InfoFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            services.AddScoped<IItemFactory, ItemFactory>();
            services.AddScoped<IImageFactory, ImageFactory>();
            services.AddScoped<IStockFactory, StockFactory>();
            services.AddScoped<IRatingFactory, RatingFactory>();
        }

        public static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddTransient<IValidator<OrderItems>, OrderItemsValidator>();

            #region viewModel validators
            services.AddTransient<IValidator<CreateUpdateCategoryViewModel>, CreateUpdateCategoryViewModelValidator>();
            #endregion
        }
    }
}