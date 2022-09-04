using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class CoreApplicationServiceRegistration
{
    public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}