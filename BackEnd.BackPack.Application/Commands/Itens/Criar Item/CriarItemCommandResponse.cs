using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Enums;

namespace BackEnd.BackPack.Application.Commands.Itens.Criar_Item;

public class CriarItemCommandResponse (Item item)
{
    public Guid Id { get; set; } = item.Id;
    public string Nome { get; set; } = item.Nome;
    public string Descricao { get; set; } = item.Descricao;
    public decimal Peso { get; set; } = item.Peso;
    public decimal Durabilidade { get; set; } = item.Durabilidade;
    public decimal Tamanho { get; set; } = item.Tamanho;
    public decimal Dureza { get; set; } = item.Dureza;
    public EnumRaridade Raridade { get; set; } = item.Raridade;
    public EnumTipoItem Tipo { get; set; } = item.Tipo;

}