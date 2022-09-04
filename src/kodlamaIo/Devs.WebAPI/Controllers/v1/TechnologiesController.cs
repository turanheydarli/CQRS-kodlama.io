using Core.Application.Requests;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Devs.Application.Features.Technologies.DTOs;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class TechnologiesController : BaseController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TechnologyListModel))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet]
    public async Task<IActionResult> GetAllTechnologies([FromQuery] PageRequest pageRequest)
    {
        GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery { PageRequest = pageRequest };

        TechnologyListModel technologyListModel = await Mediator.Send(getListTechnologyQuery);

        return Ok(technologyListModel);
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TechnologyGetByIdDto))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetTechnologyById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
    {
        TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);

        return Ok(technologyGetByIdDto);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatedTechnologyDto))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost]
    public async Task<IActionResult> CreateTechnology([FromBody] CreateTechnologyCommand createTechnologyCommand)
    {
        CreatedTechnologyDto createdTechnologyDto = await Mediator.Send(createTechnologyCommand);

        return Ok(createdTechnologyDto);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedTechnologyDto))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPut]
    public async Task<IActionResult> UpdateTechnology([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
    {
        UpdatedTechnologyDto updatedTechnologyDto = await Mediator.Send(updateTechnologyCommand);

        return Ok(updatedTechnologyDto);
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedTechnologyDto))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteTechnology([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
    {
        await Mediator.Send(deleteTechnologyCommand);

        return Ok();
    }
}