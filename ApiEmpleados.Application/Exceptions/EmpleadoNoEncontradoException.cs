namespace ApiEmpleados.Application.Exceptions;

public class EmpleadoNoEncontradoException : Exception
{
    public EmpleadoNoEncontradoException(int id) : base($"No existe un empleado con id  {id}")
    {
    }
}