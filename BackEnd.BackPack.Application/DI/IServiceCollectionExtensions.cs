using MediatR.ServiceCollectionExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.BackPack.Application.DI;

public static class IServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
        => services.AddMediatR();
}