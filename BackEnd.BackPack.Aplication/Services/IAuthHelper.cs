using BackEnd.BackPack.Aplication.DTOs;

namespace BackEnd.BackPack.Aplication.Services;

public interface IAuthHelper
{
    Task<UsuarioToken> GenerateToken(UsuarioClaims usuario);
}
