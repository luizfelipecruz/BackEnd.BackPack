using BackEnd.BackPack.Application.DTOs;
using BackEnd.BackPack.Application.Exceptions;
using BackEnd.BackPack.Application.Extensions;
using BackEnd.BackPack.Application.Services;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;

namespace BackEnd.BackPack.Application.Commands.Authorize.Login;

public record LoginCommand(LoginCommandRequest Request) : IRequest<Result<LoginCommandResponse>>;
public class LoginCommandHandler(IUsuarioRepository usuarioRepository, IAuthHelper authHelper, IUnitOfWork unitOfWork) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand Body, CancellationToken cancellationToken = default)
    {
        var usuario = await usuarioRepository.GetByNomeUsuarioAsync(Body.Request.Login)
                ?? throw new ApiException("Usuário não encontrado");

        if (usuario.AccessFailedCount > 4)
            throw new ApiException("Usuário bloqueado");

        if (!usuario.IsValidPassword(Body.Request.Senha))
        {
            usuario.AccessFailedCount++;
            await usuarioRepository.UpdateAsync(usuario);
            await unitOfWork.SaveChangesAsync();
            throw new ApiException($"Senha incorreta {5 - usuario.AccessFailedCount} tentativa(s) restante(s).");
        }
        UsuarioClaims usuarioClaims = new()
        {
            IdUsuario = usuario.Id,
            Admin = usuario.Admin
        };

        var token = await authHelper.GenerateToken(usuarioClaims);

        usuario.AccessFailedCount = 0;
        await usuarioRepository.UpdateAsync(usuario);
        await unitOfWork.SaveChangesAsync();

        return Result<LoginCommandResponse>.Success(new LoginCommandResponse(token));
    }
}