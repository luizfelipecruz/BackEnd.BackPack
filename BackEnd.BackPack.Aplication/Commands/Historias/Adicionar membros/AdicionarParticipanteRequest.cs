using BackEnd.BackPack.Domain.Enuns;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Adicionar_membros;

public record AdicionarParticipanteRequest
{
    public Guid IdUsuario { get; set; }
    public Guid IdHistoria { get; set; }
    public EnumRole EnumRole { get; set; }
}