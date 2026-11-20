using BackEnd.BackPack.Domain.Enums;

namespace BackEnd.BackPack.Application.Commands.Historias.Adicionar_membros;

public record AdicionarParticipanteRequest
{
    public Guid IdUsuario { get; set; }
    public Guid IdHistoria { get; set; }
    public EnumRole EnumRole { get; set; }
}