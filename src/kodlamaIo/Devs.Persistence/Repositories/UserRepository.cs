using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<AppUser, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context) { }
}