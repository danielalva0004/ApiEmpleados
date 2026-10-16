namespace ApiEmpleados.Application.Exceptions;

public class NombreEmpleadoDuplicadoException :  Exception
{
    public  NombreEmpleadoDuplicadoException(string nombre) : base($"Ya existe un empleado con ese nombre")
    {
    }
    
    public NombreEmpleadoDuplicadoException()
        : base("Ya existe un empleado con ese nombre")
    {
    }

}