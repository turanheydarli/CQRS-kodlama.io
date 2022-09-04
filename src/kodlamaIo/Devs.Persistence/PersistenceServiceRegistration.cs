using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseNpgsql(
                    configuration.GetConnectionString("PgSql")
                    ?? throw new NullReferenceException("Assign connection string in app settings.json"))
                .EnableSensitiveDataLogging();
        });

        services.AddScoped<ITechnologyRepository, TechnologyRepository>();

        return services;
    }
}