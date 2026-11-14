using BackEnd.BackPack.Aplication.Exeptions;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Adicionar_membros;

public record AdicionarParticipanteCommand(AdicionarParticipanteRequest Request) : IRequest<Result<AdicionarParticipanteCommandResponse>>;

public class AdicionarParticipanteCommandHandler(IUsuarioHistoriaRepository usuarioHistoriaRepository, IUnitOfWork unitOfWork) : IRequestHandler<AdicionarParticipanteCommand, Result<AdicionarParticipanteCommandResponse>>
{
    public async Task<Result<AdicionarParticipanteCommandResponse>> Handle(AdicionarParticipanteCommand body, CancellationToken cancellationToken = default)
    {
        if (await usuarioHistoriaRepository.AnyByUsuarioAndHistoria(body.Request.IdUsuario, body.Request.IdHistoria))
            throw new ApiException("O usuário já é um participante desta história.");

        var usuarioHistoria = new UsuarioHistoria
        {
            IdUsuario = body.Request.IdUsuario,
            IdHistoria = body.Request.IdHistoria,
            EnumRole = body.Request.EnumRole
        };

        await usuarioHistoriaRepository.AddAsync(usuarioHistoria);
        await unitOfWork.SaveChangesAsync();
        return Result<AdicionarParticipanteCommandResponse>.Success(new AdicionarParticipanteCommandResponse(usuarioHistoria));
    }
}