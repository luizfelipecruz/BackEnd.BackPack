namespace BackEnd.BackPack.Infrastructure.Roles;

public static class Role
{
    public const string Player = "Jogador";
    public const string Master = "Mestre";
    public const string Observer = "Observador";

    public static readonly IEnumerable<string> Roles = [Player, Master, Observer];
}