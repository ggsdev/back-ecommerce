using E_Commerce.Common;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Infra.Data.ControlAccess.Infos.Repositories;
using E_Commerce.Infra.Data.ControlAccess.Users.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infra.Data
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>();

            RegisterRepositories(services);
        }

        static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInfoRepository, InfoRepository>();
        }
    }
}