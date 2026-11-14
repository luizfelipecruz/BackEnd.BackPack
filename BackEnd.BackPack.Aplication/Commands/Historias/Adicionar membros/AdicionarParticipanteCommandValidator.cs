using BackEnd.BackPack.Domain.Enuns;
using FluentValidation;

namespace BackEnd.BackPack.Aplication.Commands.Historias.Adicionar_membros;

public class AdicionarParticipanteCommandValidator : AbstractValidator<AdicionarParticipanteCommand>
{
    public AdicionarParticipanteCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull()
            .WithMessage("Os dados do participante são obrigatórios.");
    }
}
public class AdicionarParticipanteRequestValidator : AbstractValidator<AdicionarParticipanteRequest>
{
    public AdicionarParticipanteRequestValidator()
    {
        RuleFor(x => x.IdUsuario)
            .NotEmpty()
            .WithMessage("O Id do usuário é obrigatório.");

        RuleFor(x => x.IdHistoria)
            .NotEmpty()
            .WithMessage("O Id da história é obrigatório.");

        RuleFor(x => x.EnumRole)
            .Must(x => x == EnumRole.Observador || x == EnumRole.Jogador)
            .WithMessage("O papel do participante é inválido.");
    }
}