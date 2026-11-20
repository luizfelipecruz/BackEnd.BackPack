namespace BackEnd.BackPack.Application.Commands.Usuarios.CriarUsuario;

public record CriarUsuarioCommandResponse(Guid id)
{
    public Guid Id { get; } = id;
}
