using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.GetListByDynamicLanguage;

public class GetListByDynamicLanguageQueryHandler : IRequestHandler<GetListByDynamicLanguageQuery, LanguageListModel>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<LanguageListModel> Handle(GetListByDynamicLanguageQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Language> languages = await _languageRepository.GetListByDynamicAsync(
            dynamic: request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        LanguageListModel model = _mapper.Map<LanguageListModel>(languages);

        return model;
    }
}