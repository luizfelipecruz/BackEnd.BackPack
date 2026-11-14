using BackEnd.BackPack.Aplication.Exeptions;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.BackPack.Aplication.Commands.Usuarios.CriarUsuario;

public record CriarUsuarioCommand(CriarUsuarioCommandRequest Request) : IRequest<Result<CriarUsuarioCommandResponse>>;

public class CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork) : IRequestHandler<CriarUsuarioCommand, Result<CriarUsuarioCommandResponse>>
{
    public async Task<Result<CriarUsuarioCommandResponse>> Handle(CriarUsuarioCommand body, CancellationToken cancellationToken = default)
    {

        //if (await usuarioRepository.AnyByEmailAsync(body.Request.Email))
        //    throw new ApiException("Email já cadastrado");

        if (await usuarioRepository.AnyByNomeUsuarioAsync(body.Request.NomeUsuario))
            throw new ApiException("Nome de usuário já cadastrado");

        Usuario usuario = new Usuario()
        {
            UserName = body.Request.NomeUsuario,
            //Email = body.Request.Email,
            Admin = body.Request.Admin,
        };

        var passwordHasher = new PasswordHasher<Usuario>();

        string passwordHash = passwordHasher.HashPassword(usuario, body.Request.Senha);
        usuario.PasswordHash = passwordHash;

        await usuarioRepository.AddAsync(usuario);
        await unitOfWork.SaveChangesAsync();
        return Result<CriarUsuarioCommandResponse>.Success(new CriarUsuarioCommandResponse(usuario.Id), "Usuario criado com sucesso.");
    }
}