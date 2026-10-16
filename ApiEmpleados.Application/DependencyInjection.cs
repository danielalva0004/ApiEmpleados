using ApiEmpleados.Application.Interfaces.Services;
using ApiEmpleados.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEmpleados.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        
        return services;
    }
}