using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class UsuarioRepository : RepositoryAsync<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
