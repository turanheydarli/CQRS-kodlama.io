using Devs.Application.Features.Technologies.Constants;
using FluentValidation;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
{
    public CreateTechnologyCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage(TechnologyMessages.TechnologyNameCannotBeEmpty);
    }
}