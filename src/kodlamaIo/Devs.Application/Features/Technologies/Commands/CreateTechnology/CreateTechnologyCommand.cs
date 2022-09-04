using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>, IMapFrom<Technology>
{
    public string Name { get; set; }
}