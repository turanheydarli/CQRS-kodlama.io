using Devs.Application.Features.Authorizations.DTOs;
using MediatR;

namespace Devs.Application.Features.Authorizations.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}