namespace ApiEmpleados.Domain.Entities;

public class Departamento
{
    public int Id { get; init; }
    public string Nombre { get; set; } = string.Empty;
    public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}