using ApiEmpleados.Application.Exceptions;
using ApiEmpleados.Application.Interfaces.Repositories;
using ApiEmpleados.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ApiEmpleados.Infrastructure.Persistence.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly AppDbContext _context;

    public EmpleadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empleado>> ObtenerTodosAsync()
    {
        return await _context.Empleados.Include(e => e.Departamento).ToListAsync();
    }

    public async Task<Empleado?> ObtenerPorIdAsync(int id)
    {
        return await _context.Empleados.Include(e => e.Departamento)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AgregarAsync(Empleado empleado)
    {
        await _context.Empleados.AddAsync(empleado);
    }

    public void Eliminar(Empleado empleado)
    {
        _context.Empleados.Remove(empleado);
    }
    
    public async Task GuardarCambiosAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is PostgresException postgresException &&
                  postgresException.SqlState == PostgresErrorCodes.UniqueViolation &&
                  postgresException.ConstraintName == "IX_Empleados_Nombre_Normalizado")
        {
            throw new NombreEmpleadoDuplicadoException();
        }
    }

    
    public async Task<bool> ExistePorNombreAsync(string nombre)
    {
        var nombreNormalizado = nombre.Trim().ToLower();

        return await _context.Empleados
            .AnyAsync(e => e.Nombre.Trim().ToLower() == nombreNormalizado);
    }

    public async Task<bool> ExistePorNombreExceptoIdAsync(string nombre, int id)
    {
        var nombreNormalizado = nombre.Trim().ToLower();
        return await _context.Empleados.AnyAsync(e =>
            e.Id != id &&
            e.Nombre.Trim().ToLower() == nombreNormalizado
        );
    }
}