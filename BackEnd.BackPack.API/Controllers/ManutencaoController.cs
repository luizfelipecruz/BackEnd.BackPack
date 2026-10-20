using BackEnd.BackPack.Aplication.Commands.Authorize;
using BackEnd.BackPack.Domain.Extensions;
using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ManutencaoController : BaseApiController<ManutencaoController>

{
    public ManutencaoController(IMediator mediator, ILogger<ManutencaoController> logger) : base(mediator, logger)
    {
    }

    [HttpGet("Health")]
    public async Task<ActionResult<Result<UsuarioToken>>> Health()
      => Ok("O bagulho tá rodando!");
}