using System.Linq.Expressions;
using Domain.Courses;

namespace Application.Users.Exceptions;

public abstract class CourseException : Exception
{
    public CourseId CourseId { get; }

    protected CourseException(CourseId courseId, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        CourseId = courseId;
    }
}

public class CourseAlreadyExistsException : CourseException
{
    public CourseAlreadyExistsException(CourseId courseId, string message) 
        : base(courseId, message) { }
}

public class CourseInvalidDateException : CourseException
{
    public CourseInvalidDateException(CourseId courseId) 
        : base(courseId, "Invalid date for the course.") { }
}
    