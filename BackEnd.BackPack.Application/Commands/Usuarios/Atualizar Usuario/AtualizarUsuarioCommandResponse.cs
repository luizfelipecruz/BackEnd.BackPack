namespace BackEnd.BackPack.Application.Commands.Usuarios.AtualizarUsuario;

public record AtualizarUsuarioCommandResponse(Guid id)
{
    public Guid Id { get; } = id;
}
