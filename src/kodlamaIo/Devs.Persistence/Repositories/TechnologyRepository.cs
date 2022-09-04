using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories;

public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
{
    public TechnologyRepository(BaseDbContext context) : base(context) { }
}