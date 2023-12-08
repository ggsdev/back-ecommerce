using AutoMapper;
using E_Commerce.Api._Base.Filters;
using E_Commerce.Api._Base.Handlers;
using E_Commerce.Common;
using E_Commerce.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    ConfigureJwtAuthentication(services, Configuration.SecretKey);

    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
                 builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
    });

    services.AddExceptionHandler<GlobalErrorHandler>();
    services.AddProblemDetails();

    services.AddScoped<AuthenticationFilter>();

    var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    });

    services.AddSingleton(mapperConfig.CreateMapper());

    //Infra.Data Startup Services
    E_Commerce.Infra.Data.Startup.ConfigureServices(services, configuration);

    //Domain Startup Services
    E_Commerce.Domain.Startup.ConfigureServices(services);
}

static void ConfigureJwtAuthentication(IServiceCollection services, string secretKey)
{
    var key = Encoding.ASCII.GetBytes(secretKey);

    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}