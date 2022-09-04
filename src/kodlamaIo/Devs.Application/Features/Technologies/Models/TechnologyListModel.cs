using Devs.Application.Services.Mapping;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Technologies.Models;

public class TechnologyListModel : BasePageableModel, IMapFrom<IPaginate<Technology>>
{
    public IList<TechnologyListDto> Items { get; set; }
}