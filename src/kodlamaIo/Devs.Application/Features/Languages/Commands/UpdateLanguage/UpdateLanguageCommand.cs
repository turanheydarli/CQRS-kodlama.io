using Devs.Application.Features.Languages.DTOs;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}