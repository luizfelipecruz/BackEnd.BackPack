using BackEnd.BackPack.Application.DTOs;
using BackEnd.BackPack.Application.Exceptions;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;

namespace BackEnd.BackPack.Application.Commands.Authorize.Obter_Status;

public record ObterStatusCommand(UsuarioClaims Claim) : IRequest<Result<ObterStatusResponse>>;

public class ObterStatusCommandHandler(IUsuarioRepository usuarioRepository, IUsuarioHistoriaRepository usuarioHistoriaRepository) : IRequestHandler<ObterStatusCommand, Result<ObterStatusResponse>>
{
    public async Task<Result<ObterStatusResponse>> Handle(ObterStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await usuarioRepository.GetByIdAsync(request.Claim.IdUsuario);

        if (user is null)
            throw new ApiException("Usuário não encontrado");

        if (request.Claim.IdHistoria is null)
            throw new ApiException("ID da história inválido");

        var usuarioHistoria = await usuarioHistoriaRepository.GetByIdUsuarioAsync(request.Claim.IdUsuario, request.Claim.IdHistoria.Value);

        if (usuarioHistoria is null)
            throw new ApiException("Usuário não vinculado a história");

        var response = new ObterStatusResponse
        {
            IdUsuario = request.Claim?.IdUsuario ?? Guid.Empty,
            UserName = user?.UserName ?? string.Empty,
            NomeHistoria = usuarioHistoria.Historia.Nome,
            Role = request.Claim.Role
        };

        return await Result<ObterStatusResponse>.SuccessAsync(response);
    }
}

