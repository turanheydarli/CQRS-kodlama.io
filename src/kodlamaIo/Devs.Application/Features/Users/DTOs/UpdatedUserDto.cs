using Devs.Application.Services.Mapping;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Users.DTOs;

public class UpdatedUserDto : IMapFrom<AppUser>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string GitHubUrl { get; set; }
}