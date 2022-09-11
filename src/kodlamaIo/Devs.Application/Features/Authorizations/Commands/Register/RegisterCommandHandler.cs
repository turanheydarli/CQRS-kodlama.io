using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Authorizations.DTOs;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Authorizations.Commands.Register;

public class RegisterCommandHandler:IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly UserBusinessRules _userBusinessRules;
    
    public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _authService = authService;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
        
        HashingHelper.CreatePasswordHash(request.Password, out var passWordHash, out var passwordSalt);

        AppUser user = new AppUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = passWordHash,
            PasswordSalt = passwordSalt,
            Status = true,
        };

        AppUser createdUser = await _userRepository.AddAsync(user);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        RegisteredDto registeredDto = new RegisteredDto
        {
            AccessToken = createdAccessToken
        };

        return registeredDto;
    }
}