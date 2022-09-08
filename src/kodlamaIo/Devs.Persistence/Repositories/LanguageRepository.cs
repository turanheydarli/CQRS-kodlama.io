using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories;

public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
{
    public LanguageRepository(BaseDbContext context) : base(context) { }
}