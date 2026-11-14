using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Aplication.Services;

public interface IAuthHelper
{
    Task<UsuarioToken> GenerateToken(Usuario usuario);
}
