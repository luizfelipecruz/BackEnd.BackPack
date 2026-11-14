using FluentValidation;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Criar_Historia;

public class CriarHistoriaCommandValidator : AbstractValidator<CriarHistoriaCommand>
{
    public CriarHistoriaCommandValidator()
    {
        RuleFor(x => x.Request).NotNull();
    }
}

public class CriarHistoriaRequestValidator : AbstractValidator<CriarHistoriaCommandRequest>
{
    public CriarHistoriaRequestValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty()
            .WithMessage("O título da história é obrigatório.")
            .Length(3, 100)
            .WithMessage("O título da história deve ter entre 3 e 100 caracteres.");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("A descrição da história é obrigatória.")
            .Length(10, 500)
            .WithMessage("A descrição da história deve ter entre 10 e 500 caracteres.");

        RuleFor(x => x.IdMestre)
            .NotEmpty()
            .WithMessage("O ID do mestre é obrigatório.");
    }
}
