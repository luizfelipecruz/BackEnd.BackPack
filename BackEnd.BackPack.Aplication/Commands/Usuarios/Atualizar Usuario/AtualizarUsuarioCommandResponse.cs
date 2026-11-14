namespace BackEnd.BackPack.Aplication.Commands.Usuarios.AtualizarUsuario;

public sealed class AtualizarUsuarioCommandResponse(Guid id)
{
    public Guid Id { get; } = id;
}
