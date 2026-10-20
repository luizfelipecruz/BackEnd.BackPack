using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Domain.Entidades;

public class Item : EntidadeCompleta
{
    public decimal Peso { get; set; }
    public decimal Durabilidade { get; set; }
    public decimal Tamanho { get; set; }
    public decimal Dureza { get; set; }
    public EnumRaridade Raridade { get; set; }
    public EnumTipoItem Tipo { get; set; }
    public virtual ICollection<Inventario> Inventarios { get; set; }
}