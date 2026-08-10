using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonagemController : BaseApiController<PersonagemController>

{
    public PersonagemController(IMediator mediator, ILogger<PersonagemController> logger) : base(mediator, logger)
    {
    }

}