namespace BackEnd.BackPack.Domain.Entidades;

public class Personagem : EntidadeCompleta
{
    public int Nivel { get; set; }
    public decimal Experiencia { get; set; }
    public decimal PesoMaximo { get; set; }
    public Guid IdHistoria { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdLocal { get; set; }

    public virtual Historia Historia { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual Local Local { get; set; }
    public virtual ICollection<Inventario> ItensInventario { get; set; }
}