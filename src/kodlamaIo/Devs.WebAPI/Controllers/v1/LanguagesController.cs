using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Dynamic;
using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Devs.Application.Features.Languages.Commands.DeleteLanguage;
using Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Devs.Application.Features.Languages.DTOs;
using Devs.Application.Features.Languages.Models;
using Devs.Application.Features.Languages.Queries.GetListByDynamicLanguage;
using Devs.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class LanguagesController : BaseController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet]
    public async Task<IActionResult> GetListLanguage([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };

        LanguageListModel languageListModel = await Mediator.Send(getListLanguageQuery);

        return Ok(languageListModel);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost("get-by-dynamic")]
    public async Task<IActionResult> GetListLanguageByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListByDynamicLanguageQuery getListByDynamicLanguageQuery =
            new() { PageRequest = pageRequest, Dynamic = dynamic };

        LanguageListModel languageListModel = await Mediator.Send(getListByDynamicLanguageQuery);

        return Ok(languageListModel);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatedLanguageDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost]
    public async Task<IActionResult> CreateLanguage([FromBody] CreateLanguageCommand createLanguageCommand)
    {
        CreatedLanguageDto createdLanguageDto = await Mediator.Send(createLanguageCommand);

        return Ok(createdLanguageDto);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedLanguageDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPut]
    public async Task<IActionResult> UpdateLanguage([FromBody] UpdateLanguageCommand updateLanguageCommand)
    {
        UpdatedLanguageDto updatedLanguageDto = await Mediator.Send(updateLanguageCommand);

        return Ok(updatedLanguageDto);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteTechnology([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
    {
        await Mediator.Send(deleteLanguageCommand);

        return Ok();
    }
}