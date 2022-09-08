using Core.Application.Requests;
using Devs.Application.Features.Languages.Models;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.GetListLanguage;

public class GetListLanguageQuery : IRequest<LanguageListModel>
{
    public PageRequest PageRequest { get; set; }
}