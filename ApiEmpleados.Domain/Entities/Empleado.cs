namespace ApiEmpleados.Domain.Entities;

public class Empleado
{
    public int Id { get; init; }
    public string Nombre { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public string PasswordInterno { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
}