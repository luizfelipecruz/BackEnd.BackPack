using BackEnd.BackPack.Application.Exceptions;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.BackPack.Application.Commands.Usuarios.AtualizarUsuario;

public record AtualizarUsuarioCommand(Guid id, AtualizarUsuarioCommandRequest Request) : IRequest<Result<string>>;

public class AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork) : IRequestHandler<AtualizarUsuarioCommand, Result<string>>
{
    public async Task<Result<string>> Handle(AtualizarUsuarioCommand body, CancellationToken cancellationToken = default)
    {
        var usuario = await usuarioRepository.GetByIdAsync(body.id)
            ?? throw new ApiException("Usuário não encontrado");

        if (await usuarioRepository.AnyByEmailAsync(body.Request.Email, body.id))
            throw new ApiException("Email já cadastrado");

        if (await usuarioRepository.AnyByNomeUsuarioAsync(body.Request.NomeUsuario, body.id))
            throw new ApiException("Nome de usuário já cadastrado");

        usuario.UserName = body.Request.NomeUsuario;
        usuario.Email = body.Request.Email;
        usuario.Admin = true;

        var passwordHasher = new PasswordHasher<Usuario>();

        string passwordHash = passwordHasher.HashPassword(usuario, body.Request.Senha);
        usuario.PasswordHash = passwordHash;

        await usuarioRepository.UpdateAsync(usuario);
        await unitOfWork.SaveChangesAsync();
        return Result<string>.Success("Usuario Atualizado com sucesso.");
    }
}