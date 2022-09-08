using Core.Persistence.Repositories;

namespace Devs.Domain.Entities;

public class Language : Entity
{
    public ICollection<Technology> Technologies { get; set; }
    public string Name { get; set; }

    public Language()
    {
    }

    public Language(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}