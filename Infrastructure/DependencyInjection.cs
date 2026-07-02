using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Infrastructure.Context;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Infrastructure.DataWindows;

namespace ProductCatalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseInMemoryDatabase("ProductCatalog"),
            ServiceLifetime.Scoped);

        // PB SystemInfo equivalent — read by translated PowerScript bodies.
        services.AddHttpContextAccessor();
        services.AddScoped<IApplicationContext, ApplicationContext>();

        // Register all repositories by convention — covers every IXRepository / XRepository pair,
        // including IProductfeaturesRepository which has no explicit line below.
        var assembly = Assembly.GetExecutingAssembly();
        var repoTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));
        foreach (var implType in repoTypes)
        {
            var iface = implType.GetInterfaces().FirstOrDefault(i => i.Name == $"I{implType.Name}");
            if (iface is not null) services.AddScoped(iface, implType);
        }
        return services;
    }
}
