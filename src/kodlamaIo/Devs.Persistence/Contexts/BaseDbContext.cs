using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts;

public class BaseDbContext: DbContext
{
    protected IConfiguration Configuration { get; set; }

    
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<Technology> Technologies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PgSql")
                                     ?? throw new NullReferenceException(
                                         "Assign connection string in app settings.json"))
                .EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technology>(b =>
        {
            b.ToTable("Technologies");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
        });

        Technology[] technologyEntitySeed = { new Technology { Id = 1, Name = "C#" }, new Technology { Id = 2, Name = "PHP" } };

        modelBuilder.Entity<Technology>().HasData(technologyEntitySeed);
    }
}