namespace Core.Persistence.Repositories;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; }
    
    public Entity() { }

    public Entity(int id) : this()
    {
        Id = id;
    }
}