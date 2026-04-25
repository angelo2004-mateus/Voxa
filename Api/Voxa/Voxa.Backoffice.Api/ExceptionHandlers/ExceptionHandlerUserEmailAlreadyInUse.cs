using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Voxa.Domain.Users;

namespace Voxa.Backoffice.Api.ExceptionHandlers;

public class ExceptionHandlerUserEmailAlreadyInUse : IExceptionHandler
{
    public virtual async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not UserEmailAlreadyInUseException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
        await httpContext.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Conflict",
                Detail = exception.Message
            },
            cancellationToken);

        return true;
    }
}
