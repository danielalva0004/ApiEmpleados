using System.ComponentModel.DataAnnotations;

namespace ApiEmpleados.Application.DTOs;

public class CrearEmpleadoDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El cargo es obligatorio")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "El cargo debe tener entre 2 y 100 caracteres")]
    public string Cargo { get; set; } = string.Empty;
    
    public int DepartamentoId { get; init; }
}