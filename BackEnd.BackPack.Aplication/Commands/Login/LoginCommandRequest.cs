namespace BackEnd.BackPack.Aplication.Commands.Login;

public record LoginCommandRequest
{
    public string Login { get; set; }
    public string Senha { get; set; }
}
