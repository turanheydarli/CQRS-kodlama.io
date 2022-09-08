using AutoMapper;
using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Technologies.DTOs;

public class TechnologyListDto : IMapFrom<Technology>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Technology, TechnologyListDto>()
            .ForMember(t => t.LanguageName, opt => opt.MapFrom(p => p.Language.Name))
            .ReverseMap();
    }
}