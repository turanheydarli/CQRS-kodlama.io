using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;

    public DeleteLanguageCommandHandler(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        Language language = await _languageRepository.GetAsync(l => l.Id == request.Id);

        await _languageRepository.DeleteAsync(language);

        return Unit.Value;
    }
}