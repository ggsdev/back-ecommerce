using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Infos.Services;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Domain
{
    public class Startup
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInfoService, InfoService>();
        }
    }
}
