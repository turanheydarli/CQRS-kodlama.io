using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Devs.Application.Features.Languages.Models;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.GetListByDynamicLanguage;

public class GetListByDynamicLanguageQuery : IRequest<LanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}