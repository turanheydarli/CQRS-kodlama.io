using Devs.Application.Features.Authorizations.Commands.Register;
using Devs.Application.Features.Authorizations.DTOs;
using Devs.Application.Features.Authorizations.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class AuthsController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        RegisteredDto registerDto = await Mediator.Send(registerCommand);
        return Created("", registerDto.AccessToken);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
    {
        LoginedDto loginDto = await Mediator.Send(loginQuery);
        return Ok(loginDto);
    }
}