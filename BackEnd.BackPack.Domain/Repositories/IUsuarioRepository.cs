using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Domain.Repositories;

public interface IUsuarioRepository : IRepositoryAsync<Usuario>
{
    Task<Usuario> GetByNomeUsuarioAsync(string nomeUsuario);
    Task<bool> AnyByNomeUsuarioAsync(string nomeUsuario, Guid? id = null);
    Task<bool> AnyByEmailAsync(string email, Guid? id = null);
}
