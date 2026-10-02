namespace ApiEmpleados.Model;

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public string PasswordInterno { get; set; } = string.Empty;
}