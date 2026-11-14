namespace BackEnd.BackPack.Domain.Entidades;

public class UsuarioToken
{
    public bool Authenticated { get; set; }
    public DateTime Expiration { get; set; }
    public string Token { get; set; }
}