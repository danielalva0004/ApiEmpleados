using ApiEmpleados.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleados.Data;

public class AppDbContext:DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    DbSet<Empleado> Empleados { get; set; }
    
}