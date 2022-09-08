using MediatR;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest
{
    public int Id { get; set; }
}