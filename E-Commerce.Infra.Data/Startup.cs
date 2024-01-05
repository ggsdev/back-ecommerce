using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Domain.Product.Categories.Interfaces;
using E_Commerce.Domain.Product.Images.Interfaces;
using E_Commerce.Domain.Product.Items.Interfaces;
using E_Commerce.Domain.Product.Ratings.Interfaces;
using E_Commerce.Domain.Product.Stocks.Interfaces;
using E_Commerce.Infra.Data.ControlAccess.Infos.Repositories;
using E_Commerce.Infra.Data.ControlAccess.Sessions.Repositories;
using E_Commerce.Infra.Data.ControlAccess.Users.Repositories;
using E_Commerce.Infra.Data.Product.Categories.Repositories;
using E_Commerce.Infra.Data.Product.Images.Repositories;
using E_Commerce.Infra.Data.Product.Items.Repositories;
using E_Commerce.Infra.Data.Product.Ratings.Repositories;
using E_Commerce.Infra.Data.Product.Stocks.Repositories;
using E_Commerce.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infra.Data
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();

            RegisterRepositories(services);
        }

        static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInfoRepository, InfoRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
        }
    }
}