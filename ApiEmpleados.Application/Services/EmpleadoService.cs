using ApiEmpleados.Application.DTOs;
using ApiEmpleados.Application.Enums;
using ApiEmpleados.Application.Exceptions;
using ApiEmpleados.Application.Interfaces.Repositories;
using ApiEmpleados.Application.Interfaces.Services;
using ApiEmpleados.Domain.Entities;

namespace ApiEmpleados.Application.Services;

public class EmpleadoService : IEmpleadoService
{
    
    private readonly IEmpleadoRepository _repository;

    public EmpleadoService(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmpleadoResponseDto>> ObtenerTodosAsync()
    {
        var empleados = await _repository.ObtenerTodosAsync();
        List<EmpleadoResponseDto> dtos = new List<EmpleadoResponseDto>();
        
        foreach (var empleado in empleados)
        {
            EmpleadoResponseDto responseDto = new EmpleadoResponseDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo
            };
            dtos.Add(responseDto);
        }
        
        return dtos;
    }

    public async Task<EmpleadoResponseDto> ObtenerPorIdAsync(int id)
    {
        
        var empleado = await _repository.ObtenerPorIdAsync(id);

        if (empleado == null)
            throw new EmpleadoNoEncontradoException(id);
        
        EmpleadoResponseDto responseDto = new EmpleadoResponseDto
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Cargo = empleado.Cargo 
        };
        
        return responseDto;
    
    }
    
    public async Task<EmpleadoResponseDto?> AgregarAsync(CrearEmpleadoDto dto)
    {

        // var validation = await _repository.ExistePorNombreAsync(dto.Nombre);
        // if (validation)
        // {
        //     throw new NombreEmpleadoDuplicadoException(dto.Nombre);
        // }
        
        // 1. convertir dto → Empleado
        Empleado empleado = new Empleado
        {
            Nombre = dto.Nombre.Trim(),
            Cargo = dto.Cargo.Trim()
        };
        
        // 2. _repository.AgregarAsync(...)
        await _repository.AgregarAsync(empleado);

        // 3. _repository.GuardarCambiosAsync()
        await _repository.GuardarCambiosAsync();

        // 4. responde al cliente
        EmpleadoResponseDto responseDto = new EmpleadoResponseDto
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Cargo = empleado.Cargo
        };


        return  responseDto;

    }
    
    public async Task<ActualizarEmpleadoResultado> ActualizarEmpleadoAsync(
        int id,
        ActualizarEmpleadoDto dto)
    {
        var empleado = await _repository.ObtenerPorIdAsync(id);

        if (empleado == null)
            return ActualizarEmpleadoResultado.NoEncontrado;

        var nombreOcupado =
            await _repository.ExistePorNombreExceptoIdAsync(dto.Nombre, id);

        if (nombreOcupado)
        {
            return ActualizarEmpleadoResultado.NombreDuplicado;
        }

        empleado.Nombre = dto.Nombre.Trim();
        empleado.Cargo = dto.Cargo.Trim();

        await _repository.GuardarCambiosAsync();

        return ActualizarEmpleadoResultado.Actualizado;
    }

    public async Task EliminarAsync(int id)
    {
        var empleado = await _repository.ObtenerPorIdAsync(id);
        
        if (empleado == null)
            
            throw new EmpleadoNoEncontradoException(id);
        
        // 3. Marcarlo para eliminar
        _repository.Eliminar(empleado);
        
        // 4. Guardar cambios
        await _repository.GuardarCambiosAsync();
        
    }
    
 
}