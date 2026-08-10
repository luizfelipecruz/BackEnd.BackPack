using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class HistoriaRepository : RepositoryAsync<Historia>, IHistoriaRepository
{
    public HistoriaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
