namespace ApiEmpleados.Application.DTOs;
public class EmpleadoResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    
    
    public int DepartamentoId { get; init; }
    public string DepartamentoNombre { get; set; } = string.Empty;
}