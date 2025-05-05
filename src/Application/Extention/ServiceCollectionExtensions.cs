using System;
using Application.Interface;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extention;

public static class ServiceCollectionExtensions
{
   
    public static IServiceCollection AddApplication(this IServiceCollection services){
    services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
    services.AddScoped<IAuthenticationService, AuthenticationService>();

    return services;
}
}

