using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Aplication.DTOs;

public class UsuarioToken
{
    public bool Authenticated { get; set; }
    public DateTime Expiration { get; set; }
    public Guid? IdHistoria { get; set; }
    public Guid? IdUsuario { get; set; }
    public EnumRole? Role { get; set; }
    public string Token { get; set; }
}