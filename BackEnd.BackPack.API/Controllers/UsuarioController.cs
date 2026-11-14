using BackEnd.BackPack.Aplication.Commands.Usuarios.AtualizarUsuario;
using BackEnd.BackPack.Aplication.Commands.Usuarios.CriarUsuario;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : BaseApiController<UsuarioController>
{
    public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger) : base(mediator, logger)
    {
    }

    [HttpPost]
    public async Task<ActionResult<Result<CriarUsuarioCommandResponse>>> CriarUsuario([FromBody] CriarUsuarioCommandRequest request)
    {
        var command = new CriarUsuarioCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Result<AtualizarUsuarioCommandResponse>>> AtualizarUsuario([FromRoute] Guid id, [FromBody] AtualizarUsuarioCommandRequest request)
    {
        var command = new AtualizarUsuarioCommand(id, request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}