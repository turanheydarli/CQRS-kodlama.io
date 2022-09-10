using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using Devs.Application.Features.Users.Commands.UpdateUser;
using Devs.Application.Features.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class UsersController : BaseController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedUserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
    {
        updateUserCommand.Id = User.GetUserId();
        
        UpdatedUserDto updatedUserDto = await Mediator.Send(updateUserCommand);

        return Ok(updatedUserDto);
    }
}