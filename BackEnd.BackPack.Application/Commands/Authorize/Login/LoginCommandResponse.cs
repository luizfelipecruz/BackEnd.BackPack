using BackEnd.BackPack.Application.DTOs;

namespace BackEnd.BackPack.Application.Commands.Authorize.Login;

public record LoginCommandResponse(UsuarioToken Tokendetails)
{
    public string ReturnedToken { get; } = Tokendetails.Token;
    public DateTime Expiration { get; set; } = Tokendetails.Expiration;
}