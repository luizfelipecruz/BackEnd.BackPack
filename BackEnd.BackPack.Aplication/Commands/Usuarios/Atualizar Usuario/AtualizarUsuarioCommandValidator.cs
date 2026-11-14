using FluentValidation;

namespace BackEnd.BackPack.Aplication.Commands.Usuarios.AtualizarUsuario;

public class AtualizarUsuarioCommandValidator : AbstractValidator<AtualizarUsuarioCommand>
{
    public AtualizarUsuarioCommandValidator()
    {
        RuleFor(x => x.Request).NotNull();
    }
}

public class AtualizarUsuarioRequestValidator : AbstractValidator<AtualizarUsuarioCommandRequest>
{

    public AtualizarUsuarioRequestValidator()
    {
        RuleFor(x => x.NomeUsuario)
               .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
               .Length(3, 20).WithMessage("O nome de usuário deve ter entre 3 e 20 caracteres.")
               .Must(x => x.Trim() == x).WithMessage("O nome de usuário não pode conter espaços.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.");
        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
    }
}


