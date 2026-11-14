using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Domain.Entidades;

public class Historia : EntidadeCompleta
{
    public enumStatusHistoria StatusHistoria { get; set; }

    public virtual ICollection<UsuarioHistoria> Usuarios { get; set; }
    public virtual ICollection<Personagem> Personagens { get; set; }
    public virtual ICollection<Local> Locais { get; set; }
    public virtual ICollection<Itens> Itens { get; set; }
}
