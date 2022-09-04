using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Features.Technologies.Constants;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Technologies.Rules;

public class TechnologyBusinessRules
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }


    public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var result = await _technologyRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(TechnologyMessages.TechnologyNameExist);
    }

    public void TechnologyShouldExistWhenRequested(Technology technology)
    {
        if (technology == null) throw new BusinessException(TechnologyMessages.TechnologyDoesNotExist);
    }
}