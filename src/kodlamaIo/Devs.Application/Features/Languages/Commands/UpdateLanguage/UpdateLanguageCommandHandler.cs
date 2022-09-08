using AutoMapper;
using Devs.Application.Features.Languages.DTOs;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        Language language = await _languageRepository.GetAsync(l => l.Id == request.Id);

        language.Name = request.Name;
        language.Updated = DateTime.UtcNow;

        await _languageRepository.UpdateAsync(language);

        UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(language);

        return updatedLanguageDto;
    }
}