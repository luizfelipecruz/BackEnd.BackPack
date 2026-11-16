using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class UsuarioHistoriaRepository : RepositoryAsync<UsuarioHistoria>, IUsuarioHistoriaRepository
{
    public UsuarioHistoriaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AnyByIdUsuario(Guid idUsuario)
       => await Query()
                .AnyAsync(x => x.IdUsuario.Equals(idUsuario));

    public async Task<bool> AnyByUsuarioAndHistoria(Guid idUsuario, Guid idHistoria)
        => await Query()
                .AnyAsync(x => x.IdUsuario.Equals(idUsuario)
                            && x.IdHistoria.Equals(idHistoria));

    public async Task<UsuarioHistoria?> GetByIdUsuarioAsync(Guid idUsuario, Guid idHistoria)
        => await Query()
                .FirstOrDefaultAsync(x => x.IdUsuario.Equals(idUsuario)
                                       && x.IdHistoria.Equals(idHistoria));

}
