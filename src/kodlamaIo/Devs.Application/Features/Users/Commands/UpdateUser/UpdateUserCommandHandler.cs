using AutoMapper;
using Devs.Application.Features.Users.DTOs;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;
    
    public UpdateUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserShouldExistWhenRequested(request.Id);

        AppUser user = await _userRepository.GetAsync(u => u.Id == request.Id);

        user.GitHubUrl ??= request.GitHubUrl;
        user.FirstName ??= request.FirstName;
        user.LastName ??= request.LastName;

        await _userRepository.UpdateAsync(user);
        
        UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(user);

        return updatedUserDto;
    }
}