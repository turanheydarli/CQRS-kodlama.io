using Core.Application.Requests;
using Devs.Application.Features.Technologies.Models;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}