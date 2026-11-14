using BackEnd.BackPack.Aplication.Commands.Historias.Adicionar_membros;
using BackEnd.BackPack.Aplication.Commands.Historias.Criar_Historia;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

public class HistoriasController : BaseApiController<HistoriasController>
{
    public HistoriasController(IMediator mediator, ILogger<HistoriasController> logger) : base(mediator, logger)
    {
    }

    [HttpPost]
    public async Task<ActionResult<Result<CriarHistoriaCommandResponse>>> CriarHistoria([FromBody] CriarHistoriaCommandRequest request)
    {
        var command = new CriarHistoriaCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("AdicionarParticipante")]
    public async Task<ActionResult<Result<AdicionarParticipanteCommandResponse>>> AdicionarParticipante([FromBody] AdicionarParticipanteRequest request)
    {
        var command = new AdicionarParticipanteCommand(request);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
