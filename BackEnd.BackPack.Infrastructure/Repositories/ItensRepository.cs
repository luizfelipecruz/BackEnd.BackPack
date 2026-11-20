using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infrastructure.DbContexts;

namespace BackEnd.BackPack.Infrastructure.Repositories;

public class ItensRepository : RepositoryAsync<Item>, IItensRepository
{
    public ItensRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
