using BackEnd.BackPack.Aplication.DTOs;

namespace BackEnd.BackPack.Aplication.Commands.Authorize.Vincular;

public record VincularHistoriaResponse(UsuarioToken usuarioToken)
{
    public string NewToken { get; set; } = usuarioToken.Token;
    public DateTime DataExpiration { get; set; } = usuarioToken.Expiration;
}