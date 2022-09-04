using AutoMapper;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetByIdTechnology;

public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public GetByIdTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository,
        TechnologyBusinessRules technologyBusinessRules)
    {
        _mapper = mapper;
        _technologyRepository = technologyRepository;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
    {
        Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

        _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

        TechnologyGetByIdDto technologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);

        return technologyGetByIdDto;
    }
}