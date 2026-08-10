using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Domain.Entidades;

public class Local : EntidadeCompleta
{
    public Guid IdHistoria { get; set; }
    public EnumTipoBioma Bioma { get; set; }


    public ICollection<Personagem> Personagens { get; set; }
    public virtual Historia Historia { get; set; }
}
