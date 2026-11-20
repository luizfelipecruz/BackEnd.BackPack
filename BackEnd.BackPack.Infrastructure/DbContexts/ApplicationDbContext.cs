using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEnd.BackPack.Infrastructure.DbContexts;

public class ApplicationDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public IDbConnection Connection => Database.GetDbConnection();

    public bool HasChanges => ChangeTracker.HasChanges();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        //modelBuilder.UseIdentityColumns();
        modelBuilder.ApplyConfiguration(new PersonagemMap());
        modelBuilder.ApplyConfiguration(new HistoriaMap());
        modelBuilder.ApplyConfiguration(new UsuarioHistoriaMap());
        modelBuilder.ApplyConfiguration(new LocalMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new ItemMap());
        modelBuilder.ApplyConfiguration(new InventarioMap());
        base.OnModelCreating(modelBuilder);
    }
}
