using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class UsuarioHistoriaRepository : RepositoryAsync<UsuarioHistoria>, IUsuarioHistoriaRepository
{
    public UsuarioHistoriaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
