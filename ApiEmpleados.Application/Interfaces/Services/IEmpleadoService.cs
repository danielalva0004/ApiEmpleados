using ApiEmpleados.Application.DTOs;
using ApiEmpleados.Application.Enums;


namespace ApiEmpleados.Application.Interfaces.Services;

public interface IEmpleadoService
{
    Task<List<EmpleadoResponseDto>> ObtenerTodosAsync();
    
    Task<EmpleadoResponseDto> ObtenerPorIdAsync(int id);

    Task<EmpleadoResponseDto> AgregarAsync(CrearEmpleadoDto dto);

    Task<ActualizarEmpleadoResultado> ActualizarEmpleadoAsync(
        int id,
        ActualizarEmpleadoDto dto);

    Task EliminarAsync(int id);
    
   


}