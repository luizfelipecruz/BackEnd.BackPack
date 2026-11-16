using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Domain.Repositories;

public interface IUsuarioHistoriaRepository : IRepositoryAsync<UsuarioHistoria>
{
    Task<bool> AnyByIdUsuario(Guid idUsuario);
    Task<bool> AnyByUsuarioAndHistoria(Guid idUsuario, Guid idHistoria);
    Task<UsuarioHistoria> GetByIdUsuarioAsync(Guid idUsuario, Guid idHistoria);
}
