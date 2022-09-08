using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.DTOs;

public class CreatedLanguageDto : IMapFrom<Language>
{
    public int Id { get; set; }
    public string Name { get; set; }
}