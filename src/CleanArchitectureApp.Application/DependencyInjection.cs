using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
