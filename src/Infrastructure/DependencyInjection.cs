using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneInc.Server.Application.Common.Interfaces;
using OneInc.Server.Application.Common.Services;

namespace OneInc.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment )
    {
        
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration["Redis:Endpoint"];
            options.InstanceName = configuration["Redis:Instance"];
        });

        services.AddSingleton<ICacheService, RedisCacheService>();
        
        return services;
    }
}
