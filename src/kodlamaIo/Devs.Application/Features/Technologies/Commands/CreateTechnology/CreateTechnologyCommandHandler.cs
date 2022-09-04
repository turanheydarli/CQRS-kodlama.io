using AutoMapper;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository,
        TechnologyBusinessRules technologyBusinessRules)
    {
        _mapper = mapper;
        _technologyRepository = technologyRepository;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

        Technology mappedTechnology = _mapper.Map<Technology>(request);

        Technology technology = await _technologyRepository.AddAsync(mappedTechnology);


        CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(technology);

        return createdTechnologyDto;
    }
}