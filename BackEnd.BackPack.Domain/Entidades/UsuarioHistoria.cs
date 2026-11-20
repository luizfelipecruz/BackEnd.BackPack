using BackEnd.BackPack.Domain.Enums;

namespace BackEnd.BackPack.Domain.Entidades;

public class UsuarioHistoria : EntidadeBase
{
    public Guid IdUsuario { get; set; }
    public Guid IdHistoria { get; set; }
    public EnumRole EnumRole { get; set; }

    public virtual Usuario Usuario { get; set; }
    public virtual Historia Historia { get; set; }
}
