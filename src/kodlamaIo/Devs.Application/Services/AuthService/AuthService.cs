using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    readonly ITokenHelper _tokenHelper;

    public AuthService(ITokenHelper tokenHelper, IUserRepository userRepository)
    {
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
    }

    public async Task<AccessToken> CreateAccessToken(AppUser appUser)
    {
        User user = await _userRepository.GetAsync(
            predicate: u => u.Id == appUser.Id,
            include: u => u.Include(p => p.UserOperationClaims)
                .ThenInclude(o => o.OperationClaim));

        IEnumerable<OperationClaim> operationClaims = user.UserOperationClaims.Select(o => o.OperationClaim);
            
        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims.ToList());
        
        return accessToken;
    }
}