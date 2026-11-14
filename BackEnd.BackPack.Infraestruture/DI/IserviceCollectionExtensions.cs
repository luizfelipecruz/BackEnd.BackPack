using BackEnd.BackPack.Aplication.Services;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;
using BackEnd.BackPack.Infraestruture.Repositories;
using BackEnd.BackPack.Infraestruture.Roles;
using BackEnd.BackPack.Infraestruture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
        services.AddScoped<IAuthHelper, AuthHelper>();
        return services;
    }



    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<Usuario, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = configuration["TokenConfiguration:Audience"],
                ValidIssuer = configuration["TokenConfiguration:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        configuration["Jwt:key"]
                        ?? throw new InvalidOperationException(
                            "Jwt:key não configurada.")
                    ))
            };
        });

        services.AddAuthorizationBuilder()
            .AddPolicy(Role.Master,
                policy => policy.RequireRole(Role.Master))
            .AddPolicy(Role.Player,
                policy => policy.RequireRole(Role.Player))
            .AddPolicy(Role.Observer,
                policy => policy.RequireRole(Role.Observer));
    }
}