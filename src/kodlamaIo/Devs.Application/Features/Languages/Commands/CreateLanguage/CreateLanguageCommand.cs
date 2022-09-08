using Devs.Application.Features.Languages.DTOs;
using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommand : IRequest<CreatedLanguageDto>, IMapFrom<Language>
{
    public string Name { get; set; }
}