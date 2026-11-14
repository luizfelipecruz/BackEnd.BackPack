using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Adicionar_membros;

public class AdicionarParticipanteCommandResponse(UsuarioHistoria usuarioHistoria)
{
    public Guid IdUsuarioHistoria { get; set; } = usuarioHistoria.Id;
}