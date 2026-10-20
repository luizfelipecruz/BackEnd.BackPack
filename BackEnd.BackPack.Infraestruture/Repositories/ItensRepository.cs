using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class ItensRepository : RepositoryAsync<Item>, IItensRepository
{
    public ItensRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
