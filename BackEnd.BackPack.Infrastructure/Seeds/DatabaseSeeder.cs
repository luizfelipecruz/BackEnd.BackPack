using BackEnd.BackPack.Application.Exceptions;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Enums;
using BackEnd.BackPack.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.BackPack.Infrastructure.Seeds;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(
        IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider
            .GetRequiredService<UserManager<Usuario>>();

        var dbContext = serviceProvider
            .GetRequiredService<ApplicationDbContext>();

        // 1. Criar administrador
        const string adminEmail = "admin@backpack.com";

        var admin = await userManager.FindByEmailAsync(adminEmail);

        if (admin is null)
        {
            admin = new Usuario
            {
                UserName = "admin",
                Email = adminEmail,
                Admin = true,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(
                admin,
                "Admin@123456");

            if (!result.Succeeded)
            {
                throw new ApiException(
                    string.Join("; ", result.Errors.Select(e => e.Description)));
            }
        }

        // 2. Criar história base
        var historia = await dbContext.Set<Historia>()
            .FirstOrDefaultAsync(x => x.Nome == "A Primeira Aventura");

        if (historia is null)
        {
            historia = new Historia
            {
                Nome = "A Primeira Aventura",
                Descricao = "História inicial para explorar as funcionalidades do BackPack.",
                StatusHistoria = enumStatusHistoria.EmPlanejamento
            };

            await dbContext.Set<Historia>().AddAsync(historia);
            await dbContext.SaveChangesAsync();
        }

        // 3. Vincular administrador à história como Mestre
        var vinculoExiste = await dbContext.Set<UsuarioHistoria>()
            .AnyAsync(x =>
                x.IdUsuario == admin.Id &&
                x.IdHistoria == historia.Id);

        if (!vinculoExiste)
        {
            var vinculo = new UsuarioHistoria
            {
                IdUsuario = admin.Id,
                IdHistoria = historia.Id,
                EnumRole = EnumRole.Mestre
            };

            await dbContext.Set<UsuarioHistoria>().AddAsync(vinculo);
            await dbContext.SaveChangesAsync();
        }
    }
}
