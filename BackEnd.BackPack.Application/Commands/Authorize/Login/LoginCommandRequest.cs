namespace BackEnd.BackPack.Application.Commands.Authorize.Login;

public record LoginCommandRequest
{
    public string Login { get; set; }
    public string Senha { get; set; }
}
