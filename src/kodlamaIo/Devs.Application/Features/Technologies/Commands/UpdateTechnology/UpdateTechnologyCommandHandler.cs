using AutoMapper;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
    {
        _mapper = mapper;
        _technologyRepository = technologyRepository;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
    {
        Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);
        
        _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

        technology.Name = request.Name;
        technology.Updated = DateTime.UtcNow;

        await _technologyRepository.UpdateAsync(technology);

        UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(technology);

        return updatedTechnologyDto;
    }
}