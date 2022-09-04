using MediatR;

namespace Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommand : IRequest
{
    public int Id { get; set; }
}