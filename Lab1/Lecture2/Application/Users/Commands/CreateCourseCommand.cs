using Application.Common;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Application.Users.Exceptions;
using Domain.Courses;
using MediatR;

namespace Application.Users.Commands;

public record CreateCourseCommand : IRequest<Result<Course, CourseException>>    
{
    public string Name { get; init; }
    public DateTime StartAt { get; init; }
    public DateTime FinishAt { get; init; }
    public int MaxStudents { get; init; }
}


public class CreateCourseCommandHandler(
    ICoursesRepository coursesRepository,
    ICoursesQueries coursesQueries)
    : IRequestHandler<CreateCourseCommand, Result<Course, CourseException>>
{
    public async Task<Result<Course, CourseException>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var existingCourse = await coursesQueries.GetByName(request.Name, cancellationToken);
        if (existingCourse != null)
        {
            return new CourseAlreadyExistsException(CourseId.Empty, $"Course with name '{request.Name}' already exists.");
        }

        if (request.StartAt < DateTime.UtcNow || request.FinishAt <= request.StartAt)
        {
            return new CourseInvalidDateException(CourseId.Empty);
        }

        // Create new course
        var course = new Course(
            CourseId.New(),
            request.Name,
            request.StartAt,
            request.FinishAt,
            request.MaxStudents);

        return await coursesRepository.Create(course, cancellationToken);
    }
}
