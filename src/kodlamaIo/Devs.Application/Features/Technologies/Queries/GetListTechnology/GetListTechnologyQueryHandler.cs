using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        TechnologyListModel technologyListModel = _mapper.Map<TechnologyListModel>(technologies);

        return technologyListModel;
    }
}