using ApiEmpleados.Application.Interfaces.Repositories;
using ApiEmpleados.Infrastructure.Persistence;
using ApiEmpleados.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEmpleados.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreSQL")
            )
        );

        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

        return services;
    }
}