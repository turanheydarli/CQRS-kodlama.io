using Devs.Application.Features.Authorizations.DTOs;
using MediatR;

namespace Devs.Application.Features.Authorizations.Queries.Login;

public class LoginQuery : IRequest<LoginedDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}