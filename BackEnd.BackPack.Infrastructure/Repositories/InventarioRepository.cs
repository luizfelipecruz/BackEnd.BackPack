using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infrastructure.DbContexts;

namespace BackEnd.BackPack.Infrastructure.Repositories;

public class InventarioRepository : RepositoryAsync<Inventario>, IInventarioRepository
{
    public InventarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
