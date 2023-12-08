using E_Commerce.Domain.ControlAccess.Infos.Factories;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Infos.Services;
using E_Commerce.Domain.ControlAccess.Sessions.Interfaces;
using E_Commerce.Domain.ControlAccess.Sessions.Services;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Factories;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Services;
using E_Commerce.Domain.ControlAccess.Users.Validators;
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
        }

        public static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IInfoFactory, InfoFactory>();
        }

        public static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<User>, UserValidator>();
        }
    }
}
