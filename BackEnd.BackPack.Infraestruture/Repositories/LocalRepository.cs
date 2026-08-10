using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class LocalRepository : RepositoryAsync<Local>, ILocalRepository
{
    public LocalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
