using Core.Persistence.Paging;
using Devs.Application.Features.Languages.DTOs;
using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.Models;

public class LanguageListModel : BasePageableModel, IMapFrom<IPaginate<Language>>
{
    public IList<LanguageListDto> Items { get; set; }
}