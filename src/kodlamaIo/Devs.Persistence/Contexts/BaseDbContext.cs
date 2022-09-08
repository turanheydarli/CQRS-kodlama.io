using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }


    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<Language> Languages { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    
    public DbSet<AppUser> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PgSql")
                                     ?? throw new NullReferenceException("Assign connection string in app settings.json"))
                .EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(b =>
        {
            b.ToTable("Languages");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");

            b.HasMany(p => p.Technologies);
        });

        modelBuilder.Entity<Technology>(b =>
        {
            b.ToTable("Technologies");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.LanguageId).HasColumnName("LanguageId");
            b.Property(p => p.Name).HasColumnName("Name");

            b.HasOne(p => p.Language);
        });
        
        modelBuilder.Entity<AppUser>(b =>
        {
            b.ToTable("Users");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Email).HasColumnName("Email");
            b.Property(p => p.Status).HasColumnName("Status");
            b.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.FirstName).HasColumnName("FirstName");
            b.Property(p => p.LastName).HasColumnName("LastName");
            b.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            b.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");

            b.HasMany(p => p.RefreshTokens);
        });
        
        modelBuilder.Entity<OperationClaim>(b =>
        {
            b.ToTable("OperationClaims");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.Name).HasColumnName("Name");
        });
        
        modelBuilder.Entity<UserOperationClaim>(b =>
        {
            b.ToTable("UserOperationClaims");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            b.Property(p => p.UserId).HasColumnName("UserId");
        });

        modelBuilder.Entity<RefreshToken>(b =>
        {
            b.ToTable("RefreshTokens");
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.Expires).HasColumnName("Expires");
            b.Property(p => p.Revoked).HasColumnName("Revoked");
            b.Property(p => p.UserId).HasColumnName("UserId");
            b.Property(p => p.Token).HasColumnName("Token");
            b.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            b.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            b.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            b.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");

        });

        OperationClaim[] operationClaimEntitySeed = { new (1,"Language.Create") };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeed);
        
        Language[] languageEntitySeed = { new(1, "C#"), new(2, "Java"), new(3, "JavaScript") };
        modelBuilder.Entity<Language>().HasData(languageEntitySeed);

        Technology[] technologyEntitySeed = { new(1, 1, "WPF"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(4, 2, "Spring"), };
        modelBuilder.Entity<Technology>().HasData(technologyEntitySeed);
    }
}