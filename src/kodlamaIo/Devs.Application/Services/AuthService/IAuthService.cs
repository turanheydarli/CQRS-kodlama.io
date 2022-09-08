using Core.Security.JWT;
using Devs.Domain.Entities;

namespace Devs.Application.Services.AuthService;

public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(AppUser user);
}