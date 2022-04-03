using System.Text.Json;
using MartianRobots.API.Models;

namespace MartianRobots.API.CustomExceptionMiddleware;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var response = new ApiResponse
        {
            IsSuccessful = false
        };

        httpContext.Response.ContentType = "application/json";
        switch (exception)
        {
            case ArgumentException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                response.ResponseCode = StatusCodes.Status400BadRequest;
                response.ErrorMessage = exception.Message;
                break;

            default:
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ErrorMessage = "An error has occurred processing your request. Please try again.";
                response.ResponseCode = StatusCodes.Status500InternalServerError;
                break;
        }

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
