namespace BackEnd.BackPack.Aplication.Commands.Usuarios.CriarUsuario;

public sealed class CriarUsuarioCommandResponse(Guid id)
{
    public Guid Id { get; } = id;
}
