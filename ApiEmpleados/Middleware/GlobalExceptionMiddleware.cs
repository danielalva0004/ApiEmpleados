using ApiEmpleados.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpleados.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrio un error durante la peticion");

            var (statusCode, title, detail) = ex switch
            {
                EmpleadoNoEncontradoException =>
                (
                    StatusCodes.Status404NotFound,
                    "Empleado no encontrado",
                    ex.Message
                ),

                NombreEmpleadoDuplicadoException =>
                (
                    StatusCodes.Status409Conflict,
                    "Conflicto",
                    ex.Message
                ),

                _ =>
                (
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor",
                    "Ocurrio un error inesperado."
                )
            };

            context.Response.StatusCode = statusCode;

            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}