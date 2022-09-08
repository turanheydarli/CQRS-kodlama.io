using Core.Security.Entities;
using Core.Security.JWT;

namespace Devs.Application.Features.Authorizations.DTOs;

public class LoginedDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}