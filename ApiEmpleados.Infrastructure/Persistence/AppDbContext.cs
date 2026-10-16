using ApiEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleados.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Empleado> Empleados { get; set; }
}
