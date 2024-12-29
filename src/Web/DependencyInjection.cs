using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OneInc.Server.Web.Common;

namespace OneInc.Server.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseTransformer()));
        });

        services.AddExceptionHandler<ApiExceptionHandler>();
        services.AddProblemDetails();
        
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddCors(options =>
        {
            options.AddPolicy("AllowWebClient",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        services.AddSwaggerGen();
        return services;
    }
}
