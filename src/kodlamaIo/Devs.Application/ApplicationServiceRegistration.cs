using System.Reflection;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Services.AuthService;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<TechnologyBusinessRules>();
        services.AddScoped<UserBusinessRules>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddTransient<IAuthService, AuthService>();
        
        services.AddTransient<ITokenHelper, JwtHelper>();

        //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        return services;
    }
}