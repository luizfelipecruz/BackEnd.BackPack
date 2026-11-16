namespace BackEnd.BackPack.Aplication.DTOs  ;

public class UsuarioClaims
{
    public Guid IdUsuario { get; set; }
    public Guid? IdHistoria { get; set; }
    public string Role { get; set; }
    public bool Admin { get; set; }
}