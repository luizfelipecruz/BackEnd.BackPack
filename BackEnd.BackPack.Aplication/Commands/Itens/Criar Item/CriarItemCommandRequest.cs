using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Aplication.Commands.Itens.Criar_Item;

public record CriarItemCommandRequest
{
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public decimal Peso { get; set; }
    public decimal Durabilidade { get; set; }
    public decimal Tamanho { get; set; }
    public decimal Dureza { get; set; }
    public EnumRaridade Raridade { get; set; }
    public EnumTipoItem Tipo { get; set; }
}