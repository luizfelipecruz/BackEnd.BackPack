
using BackEnd.BackPack.Infrastructure.DbContexts;
using BackEnd.BackPack.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.BackPack.Infrastructure.Extensions;

public static class DatabaseInitializerExtensions
{
    public static async Task InitializeDatabaseAsync(
        this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        // Executa migrations pendentes
        await dbContext.Database.MigrateAsync();

        // Executa as seeds
        await DatabaseSeeder.SeedAsync(scope.ServiceProvider);

        await ItemSeeder.SeedAsync(dbContext);
    }
}
