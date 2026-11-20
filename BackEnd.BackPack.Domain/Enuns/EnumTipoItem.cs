namespace BackEnd.BackPack.Domain.Enums;

// <summary>
// Enumeração para os tipos de itens
// Observe que os tipos de itens podem ser expandidos conforme necessário para atender aos requisitos do sistema
// O Tipo de item é usado para categorizar os itens no inventário e pode influenciar a forma como eles são usados ou equipados pelos personagens
// O Tipo Bolsa , por exemplo, pode ser usado para armazenar outros itens ou seja quando um item do tipo bolsa é adicionado ao inventário, ele Soma o seu peso ao peso total do personagem, mas não ocupa espaço de item individualmente, permitindo que o personagem carregue mais itens dentro da bolsa
// </summary>
public enum EnumTipoItem
{
    Bolsa,
    Armadura,
    Ferramenta,
    Consumivel,
    Material,
    Arma,
}
