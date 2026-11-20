using FluentValidation;

namespace BackEnd.BackPack.Application.Commands.Usuarios.CriarUsuario;

public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
{
    public CriarUsuarioCommandValidator()
    {
        RuleFor(x => x.Request).NotNull();
    }
}

public class CriarUsuarioRequestValidator : AbstractValidator<CriarUsuarioCommandRequest>
{

    public CriarUsuarioRequestValidator()
    {
        RuleFor(x => x.NomeUsuario)
               .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
               .Length(3, 20).WithMessage("O nome de usuário deve ter entre 3 e 20 caracteres.")
               .Must(x => x.Trim() == x).WithMessage("O nome de usuário não pode conter espaços.");
        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
    }
}


