using MediatR.Implementation;
using MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatR.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(x => !x.IsDynamic && !string.IsNullOrWhiteSpace(x.FullName))
            .ToArray();

        services.AddScoped<IMediator, Mediator>();

        RegisterHandlers(services, assemblies, typeof(IRequestHandler<,>));

        return services;
    }

    private static void RegisterHandlers(IServiceCollection services, Assembly[] assemblies, Type handlerInterface)
    {
        var types = assemblies.SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract)
            .ToList();

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces()
                .Where(x => x.IsGenericType &&
                x.GetGenericTypeDefinition() == handlerInterface);

            foreach (var iface in interfaces)
                services.AddTransient(iface, type);
        }
    }
}
