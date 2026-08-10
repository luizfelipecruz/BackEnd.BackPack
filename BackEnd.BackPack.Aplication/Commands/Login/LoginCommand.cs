using BackEnd.BackPack.Aplication.Commands.Login;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;


namespace BackEnd.BackPack.Aplication.Commands;

public record LoginCommand(LoginCommandRequest Request) : IRequest<Result<LoginCommandResponse>>;
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public Task<Result<LoginCommandResponse>> Handle(LoginCommand Body, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
