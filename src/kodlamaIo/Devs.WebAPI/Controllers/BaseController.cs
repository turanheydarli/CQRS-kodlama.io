using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator _mediator;
}