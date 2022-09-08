using Core.Persistence.Repositories;

namespace Devs.Domain.Entities;

public class Technology : Entity
{
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    public string Name { get; set; }

    public Technology()
    {
    }

    public Technology(int id, int languageId, string name) : this()
    {
        Id = id;
        LanguageId = languageId;
        Name = name;
    }
}