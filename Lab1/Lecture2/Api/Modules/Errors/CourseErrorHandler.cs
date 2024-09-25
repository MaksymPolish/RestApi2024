using Application.Users.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Errors;

public static class CourseErrorHandler
{
    public static ObjectResult ToObjectResult(this CourseException exception)
    {
        return new ObjectResult(exception.Message)
        {
            StatusCode = exception switch
            {
                CourseException courseException => StatusCodes.Status400BadRequest,

            }
        };
    }
}