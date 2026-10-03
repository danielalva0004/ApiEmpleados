using ApiEmpleados.DTOs;
using ApiEmpleados.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpleados.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private static readonly List<Empleado> empleados = new()
    {
        new Empleado
        {
            Id = 1,
            Nombre = "Laura",
            Cargo = "Developer"
        },
        new Empleado
        {
            Id = 2,
            Nombre = "Carlos",
            Cargo = "Tester"
        }
    };
    [HttpGet]
    public IActionResult ObtenerEmpleados()
    {
        
        return Ok(empleados);
    }
    
    
    [HttpGet("{id}")]
    public IActionResult ObtenerEmpleadoPorId(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);

        if (empleado == null)
        {
            return NotFound("Empleado no encontrado");
        }

        var respuesta = new EmpleadoResponseDto
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Cargo = empleado.Cargo
        };

        return Ok(respuesta);
    }
    
    
    [HttpPost]
    public IActionResult CrearEmpleado(CrearEmpleadoDto dto)
    {
        var empleado = new Empleado
        {
            Id = empleados.Count + 1,

            Nombre = dto.Nombre,
            Cargo = dto.Cargo,

            Salario = 0,
            PasswordInterno = "valor-generado-por-backend"
        };

        empleados.Add(empleado);

        var response = new EmpleadoResponseDto
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Cargo = empleado.Cargo
        };

        return CreatedAtAction(
            nameof(ObtenerEmpleadoPorId),
            new { id = empleado.Id },
            response
        );
    }
    
    [HttpPut("{id}")]
    public IActionResult ActualizarEmpleado(
        int id,
        ActualizarEmpleadoDto dto)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);

        if (empleado == null)
        {
            return NotFound();
        }

        empleado.Nombre = dto.Nombre;
        empleado.Cargo = dto.Cargo;

        return Ok(empleado);
    }
    [HttpDelete("{id}")]
    
    public IActionResult EliminarEmpleado(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);

        if (empleado == null)
        {
            return NotFound("Empleado no encontrado");
        }

        empleados.Remove(empleado);

        return NoContent();
    }
    
}