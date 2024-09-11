using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ToDoApp.Controllers;

public static class ErrorEndpoints
{
    public static void MapErrorEndpoints(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext context) =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            return GetErrorResultByException(exception!);
        });
    }

    private static IResult GetErrorResultByException(Exception ex)
    {
        if (ex is ItemNotFoundException)
        {
            return Results.NotFound(ex.Message);
        }

        return Results.StatusCode(500);
    }
}