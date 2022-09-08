using AutoMapper;
using Devs.Application.Features.Languages.DTOs;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository)
    {
        _mapper = mapper;
        _languageRepository = languageRepository;
    }

    public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        Language mappedLanguage = _mapper.Map<Language>(request);
        Language language = await _languageRepository.AddAsync(mappedLanguage);
        CreatedLanguageDto createdLanguageDto = _mapper.Map<CreatedLanguageDto>(language);

        return createdLanguageDto;
    }
}