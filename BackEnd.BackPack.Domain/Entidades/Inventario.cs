namespace BackEnd.BackPack.Domain.Entidades;

public class Inventario : EntidadeAuxiliar
{
    public int IdPersonagem { get; set; }
    public int IdItem { get; set; }
    public int Quantidade { get; set; }
    public bool Equipado { get; set; }
    public decimal DurabilidadeAtual { get; set; }

    public virtual Itens Item { get; set; }
    public virtual Personagem Personagem { get; set; }
}
