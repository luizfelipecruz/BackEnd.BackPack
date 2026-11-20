using BackEnd.BackPack.Application.DTOs;

namespace BackEnd.BackPack.Application.Commands.Authorize.Vincular;

public record VincularHistoriaResponse(UsuarioToken usuarioToken)
{
    public string NewToken { get; set; } = usuarioToken.Token;
    public DateTime DataExpiration { get; set; } = usuarioToken.Expiration;
}