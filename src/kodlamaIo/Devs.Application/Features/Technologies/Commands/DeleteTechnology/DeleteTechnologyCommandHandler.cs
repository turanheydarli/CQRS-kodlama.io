using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository,
        TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<Unit> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
    {
        Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

        _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

        await _technologyRepository.DeleteAsync(technology);

        return Unit.Value;
    }
}