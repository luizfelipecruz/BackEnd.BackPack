using BackEnd.BackPack.Application.DTOs;

namespace BackEnd.BackPack.Application.Services;

public interface IAuthHelper
{
    Task<UsuarioToken> GenerateToken(UsuarioClaims usuario);
}
