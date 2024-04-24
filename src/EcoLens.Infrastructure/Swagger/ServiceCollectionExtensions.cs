using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EcoLens.Infrastructure.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoLens API", Version = "v1" });
        });

        services.AddApiVersioning();

        return services;
    }
}

