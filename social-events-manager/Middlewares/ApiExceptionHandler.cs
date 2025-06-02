using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using social_events_manager.Exceptions;

namespace social_events_manager.Middlewares;

public class ApiExceptionHandler(ILogger<ApiExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        logger.LogError(exception, "An unhandled exception occurred");

        var problemDetails = new ProblemDetails
        {
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
        };

        switch (exception)
        {
            case ItemNotFoundException:
                problemDetails.Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5";
                problemDetails.Title = "Item not found";
                problemDetails.Status = (int)HttpStatusCode.NotFound;
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case InvalidInputException:
                problemDetails.Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1";
                problemDetails.Title = "Invalid input";
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case UnauthorizedException:
                problemDetails.Type = "https://tools.ietf.org/html/rfc9110#section-15.5.2";
                problemDetails.Title = "Unauthorized access";
                problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;
            default:
                problemDetails.Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1";
                problemDetails.Title = "Unexpected error";
                problemDetails.Detail = "An error occurred while processing your request";
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
