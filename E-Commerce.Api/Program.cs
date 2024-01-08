using AutoMapper;
using E_Commerce.Api._Base.Handlers;
using E_Commerce.Api._Base.Middlewares;
using E_Commerce.Infra.IoC;
using E_Commerce.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

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

    services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = configuration.GetConnectionString("Redis");
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

    //services.AddScoped<AuthenticationFilter>();

    var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    });


    services.AddSingleton(mapperConfig.CreateMapper());

    //Infra.Data Startup Services
    E_Commerce.Infra.Data.Startup.ConfigureServices(services);

    //Domain Startup Services
    E_Commerce.Domain.Startup.ConfigureServices(services);

    ConfigureSwagger(services, Configuration.SecretKey);
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

        x.Events = new JwtBearerEvents
        {
            OnForbidden = context =>
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(Constants.FORBIDDEN_DEFAULT_MESSAGE);
            }
        };
    });
}

static void ConfigureSwagger(IServiceCollection services, string jwtKey)
{
    services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "LOGIN"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    });
}