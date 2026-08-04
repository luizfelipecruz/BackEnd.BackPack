using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Domain.Entidades;

public class Itens : EntidadeBase
{
    public string Descricao { get; set; }
    public decimal Peso { get; set; }
    public decimal Durabilidade { get; set; }
    public decimal Dureza { get; set; }
    public EnumRaridade raridade { get; set; }
    public EnumTipoItem Tipo { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; }

}