using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.BackPack.Infraestruture.DI;

public static class IserviceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IItensRepository, ItensRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IHistoriaRepository, HistoriaRepository>();
        services.AddScoped<IPersonagemRepository, PersonagemRepository>();
        services.AddScoped<IInventarioRepository, InventarioRepository>();
        services.AddScoped<IUsuarioHistoriaRepository, UsuarioHistoriaRepository>();
        return services;
    }
}