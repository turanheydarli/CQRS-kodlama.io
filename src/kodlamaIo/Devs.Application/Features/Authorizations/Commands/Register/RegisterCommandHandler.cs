using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Authorizations.DTOs;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Authorizations.Commands.Register;

public class RegisterCommandHandler:IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    
    public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
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