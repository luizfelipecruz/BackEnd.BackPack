using BackEnd.BackPack.Aplication.Commands.Authorize.Login;
using BackEnd.BackPack.Aplication.Commands.Authorize.Vincular;
using BackEnd.BackPack.Aplication.Extesnions;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AutenticacaoController : BaseApiController<AutenticacaoController>
{
    public AutenticacaoController(IMediator mediator, ILogger<AutenticacaoController> logger) : base(mediator, logger)
    {
    }

    [HttpPost("Login")]
    public async Task<ActionResult<Result<LoginCommandResponse>>> Login([FromBody] LoginCommandRequest request)
    {
        var command = new LoginCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("vincular")]
    public async Task<ActionResult<Result<LoginCommandResponse>>> Vincular([FromBody] VincularHistoriaRequest request)
    {
        var userClaim = User.GetClaims();
        var command = new VincularHistoriaCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
