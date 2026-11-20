using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Application.Commands.Historias.Adicionar_membros;

public record AdicionarParticipanteResponse(UsuarioHistoria usuarioHistoria)
{
    public Guid IdUsuarioHistoria { get; set; } = usuarioHistoria.Id;
}