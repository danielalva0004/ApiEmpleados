using ApiEmpleados.Domain.Entities;

namespace ApiEmpleados.Application.Interfaces.Repositories;

public interface IEmpleadoRepository
{
    Task<List<Empleado>> ObtenerTodosAsync();

    Task<Empleado?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(Empleado empleado);

    void Eliminar(Empleado empleado);

    Task GuardarCambiosAsync();
    
    Task<bool> ExistePorNombreAsync(string nombre);
    
    Task<bool> ExistePorNombreExceptoIdAsync(string nombre, int id);
}