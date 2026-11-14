using System.ComponentModel;

namespace BackEnd.BackPack.Domain.Enuns;

public enum EnumRole
{
    [Description("Personagem")]
    Jogador = 1,

    [Description("Mestre")]
    Mestre = 2,

    [Description("Observador")]
    Observador = 3,
}