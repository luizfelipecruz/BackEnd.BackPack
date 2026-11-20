using BackEnd.BackPack.Application.Commands.Historias.Adicionar_membros;
using BackEnd.BackPack.Application.Commands.Historias.Criar_Historia;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

[Route("[controller]")]

public class HistoriasController : BaseApiController<HistoriasController>
{
    public HistoriasController(IMediator mediator, ILogger<HistoriasController> logger) : base(mediator, logger)
    {
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Result<CriarHistoriaCommandResponse>>> CriarHistoria([FromBody] CriarHistoriaCommandRequest request)
    {
        var command = new CriarHistoriaCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("AdicionarParticipante")]
    public async Task<ActionResult<Result<AdicionarParticipanteResponse>>> AdicionarParticipante([FromBody] AdicionarParticipanteRequest request)
    {
        var command = new AdicionarParticipanteCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}