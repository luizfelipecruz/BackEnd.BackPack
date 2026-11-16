using BackEnd.BackPack.Aplication.DTOs;

namespace BackEnd.BackPack.Aplication.Commands.Authorize.Login;

public record LoginCommandResponse(UsuarioToken Tokendetails)
{
    public string ReturnedToken { get; } = Tokendetails.Token;
    public DateTime Expiration { get; set; } = Tokendetails.Expiration;
}