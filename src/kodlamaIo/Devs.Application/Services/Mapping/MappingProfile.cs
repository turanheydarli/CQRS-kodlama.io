using System.Reflection;
using AutoMapper;

namespace Devs.Application.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            
            var interfaceMethodInfo = type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
            var methodInfo = type.GetMethod("Mapping");

            if (methodInfo == null)
            {
                interfaceMethodInfo?.Invoke(instance, new object[] { this });
            }
            else
            {
                methodInfo.Invoke(instance, new object[] { this });
            }
        }
    }
}