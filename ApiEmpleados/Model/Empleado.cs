namespace ApiEmpleados.Model;

public class Empleado
{
    public int Id { get; init; }
    public string Nombre { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public string PasswordInterno { get; set; } = string.Empty;
}