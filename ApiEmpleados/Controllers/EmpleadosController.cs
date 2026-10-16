using ApiEmpleados.Application.DTOs;
using ApiEmpleados.Application.Enums;
using ApiEmpleados.Application.Interfaces.Services;


using Microsoft.AspNetCore.Mvc;

namespace ApiEmpleados.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly IEmpleadoService _services;

    public EmpleadosController(IEmpleadoService service)
    {
        _services = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerEmpleados()
    {
        
        var empleados = await _services.ObtenerTodosAsync();
        
        return Ok(empleados);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerEmpleadoPorId(int id)
    {
        var empleado = await _services.ObtenerPorIdAsync(id);
        
        return Ok(empleado);
        
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AgregarEmpleado(CrearEmpleadoDto dto)
    {
        var empleado = await _services.AgregarAsync(dto);
        
        return CreatedAtAction(
            nameof(ObtenerEmpleadoPorId),
            new { id = empleado.Id },
            empleado);

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarEmpleado(int id, ActualizarEmpleadoDto dto)
    {
        var empleado = await _services.ActualizarEmpleadoAsync(id,dto);
        
        if (empleado == ActualizarEmpleadoResultado.NoEncontrado)
        {
            return NotFound();
        }
        else if(empleado == ActualizarEmpleadoResultado.NombreDuplicado)
        {
            return Conflict("Ya existe otro empleado con ese nombre");
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _services.EliminarAsync(id);
        
        return NoContent();
    }
    
    [HttpGet("error-inesperado")]
    public IActionResult ErrorInesperado()
    {
        throw new InvalidOperationException("Fallo inesperado de prueba");
    }
    
    
}