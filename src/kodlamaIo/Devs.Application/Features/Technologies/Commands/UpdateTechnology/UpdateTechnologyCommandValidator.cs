using Devs.Application.Features.Technologies.Constants;
using FluentValidation;

namespace Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandValidator: AbstractValidator<UpdateTechnologyCommand>
{
    public UpdateTechnologyCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage(TechnologyMessages.TechnologyIdCannotBeEmpty);
        RuleFor(p => p.Name).NotEmpty().WithMessage(TechnologyMessages.TechnologyNameCannotBeEmpty);
    }
}