using BackEnd.BackPack.Aplication.Exeptions;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Enuns;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Criar_Historia;

public record CriarHistoriaCommand(CriarHistoriaCommandRequest Request) : IRequest<Result<CriarHistoriaCommandResponse>>;

public class CriarHistoriaCommandHandler(IHistoriaRepository historiaRepository, IUsuarioHistoriaRepository usuarioHistoriaRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork) : IRequestHandler<CriarHistoriaCommand, Result<CriarHistoriaCommandResponse>>
{
    public async Task<Result<CriarHistoriaCommandResponse>> Handle(CriarHistoriaCommand body, CancellationToken cancellationToken = default)
    {

        if (!await usuarioRepository.AnyByIdAsync(body.Request.IdMestre))
            throw new ApiException("O Usuario informado não existe.");

        if (await historiaRepository.AnyByName(body.Request.Titulo))
            throw new ApiException("Já existe uma história com este título.");


        var historia = new Historia
        {
            Nome = body.Request.Titulo,
            Descricao = body.Request.Descricao,
        };

        var usuarioHistoria = new UsuarioHistoria
        {
            IdUsuario = body.Request.IdMestre,
            IdHistoria = historia.Id,
            EnumRole = EnumRole.Mestre
        };

        await usuarioHistoriaRepository.AddAsync(usuarioHistoria);
        await historiaRepository.AddAsync(historia);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CriarHistoriaCommandResponse>.Success(new CriarHistoriaCommandResponse { IdHistoria = historia.Id });
    }
}