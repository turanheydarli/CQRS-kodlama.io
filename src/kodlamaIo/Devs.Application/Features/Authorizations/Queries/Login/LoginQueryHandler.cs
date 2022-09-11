using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Authorizations.Constants;
using Devs.Application.Features.Authorizations.DTOs;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Authorizations.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginedDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly UserBusinessRules _userBusinessRules;
    
    public LoginQueryHandler(IUserRepository userRepository, IAuthService authService, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _authService = authService;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<LoginedDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserEmailShouldExistWhenRequested(request.Email);

        AppUser user = await _userRepository.GetAsync(u => u.Email == request.Email && u.Status);

        
        if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthorizationMessages.PasswordIsWrong);

        AccessToken accessToken = await _authService.CreateAccessToken(user);

        return new LoginedDto { AccessToken = accessToken };
    }
}