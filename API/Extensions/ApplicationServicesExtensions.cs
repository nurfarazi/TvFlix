using API.Errors;
using Core.Entity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        services.AddDbContext<StoreContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });
        services.AddSingleton<IConnectionMultiplexer>(c => 
        {
            var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis") ?? string.Empty);
            return ConnectionMultiplexer.Connect(options);
        });
            
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(MovieService));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            };
        });

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy => 
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            });
        });

        return services;
    }
}