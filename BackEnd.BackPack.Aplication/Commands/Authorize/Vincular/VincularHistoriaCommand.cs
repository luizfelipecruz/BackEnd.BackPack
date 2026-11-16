using BackEnd.BackPack.Aplication.DTOs;
using BackEnd.BackPack.Aplication.Exeptions;
using BackEnd.BackPack.Aplication.Services;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;

namespace BackEnd.BackPack.Aplication.Commands.Authorize.Vincular;

public record VincularHistoriaCommand(VincularHistoriaRequest Request, UsuarioClaims Claims) : IRequest<Result<VincularHistoriaResponse>>;

public class VincularCommandHandler(IUsuarioHistoriaRepository usuarioHistoriaRepository, IAuthHelper authHelper) : IRequestHandler<VincularHistoriaCommand, Result<VincularHistoriaResponse>>
{
    public async Task<Result<VincularHistoriaResponse>> Handle(VincularHistoriaCommand request, CancellationToken cancellationToken)
    {
        var usuarioHistoria = await usuarioHistoriaRepository.GetByIdUsuarioAsync(request.Claims.IdUsuario, request.Request.IdHistoria);

        if (usuarioHistoria is null)
            throw new ApiException("Usuário não vinculado a história");

        var usuarioClaim = new UsuarioClaims
        {
            IdUsuario = request.Claims.IdUsuario,
            Admin = request.Claims.Admin,
            IdHistoria = request.Request.IdHistoria,
            Role = usuarioHistoria.EnumRole.ToString()
        };

        var token = await authHelper.GenerateToken(usuarioClaim);

        return await Result<VincularHistoriaResponse>.SuccessAsync(new VincularHistoriaResponse(token));
    }
}