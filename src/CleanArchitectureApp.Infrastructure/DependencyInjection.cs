using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Infrastructure.Persistence;
using CleanArchitectureApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(configuration.GetValue<string>("Database:Name") ?? "CleanArchitectureAppDb"));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
