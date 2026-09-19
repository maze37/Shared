using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Framework.ResponseExtensions;

public static class ResponseExtensions
{
    public static ActionResult ToResponse(this Error error) =>
        new ObjectResult(Envelope.Fail(error))
        {
            StatusCode = GetStatusCodeFromErrorType(error.Type),
        };

    private static int GetStatusCodeFromErrorType(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.AUTHENTICATION => StatusCodes.Status401Unauthorized,
            ErrorType.AUTHORIZATION => StatusCodes.Status403Forbidden,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };
}