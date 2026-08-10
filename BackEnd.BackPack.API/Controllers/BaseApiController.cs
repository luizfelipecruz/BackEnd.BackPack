using MediatR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.BackPack.API.Controllers;

[ApiController]
public abstract class BaseApiController<T>(IMediator mediator, ILogger<T> logger) : ControllerBase
{
    protected IMediator Mediator => mediator;
    protected ILogger<T> Logger => logger;
}
