using Devs.Application.Features.Technologies.DTOs;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetByIdTechnology;

public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
{
    public int Id { get; set; }
}