using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace BackEnd.BackPack.Infraestruture.DbContexts;

public interface IApplicationDbContext
{
    IDbConnection Connection { get; }
    bool HasChanges { get; }

    EntityEntry Entry(object entity);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
