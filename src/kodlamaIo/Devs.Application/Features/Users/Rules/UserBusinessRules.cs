using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Features.Users.Constants;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.Users.Rules;

public class UserBusinessRules
{
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any()) throw new BusinessException(UserMessages.EmailAlreadyExist);
        }

        public async Task UserShouldExistWhenRequested(string email)
        {
            var result = await _userRepository.GetListAsync(b => b.Email == email);
            if (!result.Items.Any()) throw new BusinessException(UserMessages.UserNotFound);
        }
}