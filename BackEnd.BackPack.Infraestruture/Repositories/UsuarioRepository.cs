using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class UsuarioRepository : RepositoryAsync<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AnyByEmailAsync(string email, Guid? id = null)
    {
        var query = Query().Where(u => u.Email == email);
        if (id.HasValue)
            query = query.Where(u => u.Id != id);
        return await query.AnyAsync();
    }

    public async Task<bool> AnyByNomeUsuarioAsync(string nomeUsuario, Guid? id = null)
    {
        var query = Query().Where(u => u.UserName == nomeUsuario);

        if (id.HasValue)
            query = query.Where(u => u.Id != id);

        return await query.AnyAsync();
    }

    public async Task<Usuario?> GetByNomeUsuarioAsync(string nomeUsuario)
        => await Query().FirstOrDefaultAsync(u => u.UserName == nomeUsuario);

}
