using BackEnd.BackPack.Aplication.Commands.Authorize.Login;
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
}
