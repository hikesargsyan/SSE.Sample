
namespace OneInc.Server.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddExceptionHandler<AppExceptionHandler>();

        services.AddControllers();

        services.AddSwaggerGen();
        
        return services;
    }
    
}
