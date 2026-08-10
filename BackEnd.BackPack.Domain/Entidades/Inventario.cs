namespace BackEnd.BackPack.Domain.Entidades;

public class Inventario : EntidadeBase
{
    public Guid IdPersonagem { get; set; }
    public Guid IdItem { get; set; }
    public int Quantidade { get; set; }
    public bool Equipado { get; set; }
    public decimal DurabilidadeAtual { get; set; }

    public virtual Itens Item { get; set; }
    public virtual Personagem Personagem { get; set; }
}