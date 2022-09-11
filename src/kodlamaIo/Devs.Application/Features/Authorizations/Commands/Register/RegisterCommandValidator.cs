using Devs.Application.Features.Authorizations.Constants;
using FluentValidation;

namespace Devs.Application.Features.Authorizations.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).EmailAddress().WithMessage(AuthorizationMessages.EmailAddressIsNotValid);
    }
}