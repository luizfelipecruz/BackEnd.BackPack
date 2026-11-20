using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infrastructure.DbContexts;

namespace BackEnd.BackPack.Infrastructure.Repositories;

public class LocalRepository : RepositoryAsync<Local>, ILocalRepository
{
    public LocalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
