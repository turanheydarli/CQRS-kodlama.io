using Core.Security.Entities;

namespace Devs.Domain.Entities;

public class AppUser : User
{
    public string GitHubUrl { get; set; }
}