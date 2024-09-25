using Domain.Courses;

namespace Api.Dtos;

public record CourseDto(
    Guid? Id,
    string Name,
    DateTime StartAt,
    DateTime FinishAt,
    int MaxStudents,
    List<UserCourseDto>? EnrolledStudents)
{
    public static CourseDto FromDomainModel(Course course)
        => new(
            Id: course.Id.Value,
            Name: course.Name,
            StartAt: course.StartAt,
            FinishAt: course.FinishAt,
            MaxStudents: course.MaxStudents,
            EnrolledStudents: course.EnrolledStudents?.Select(UserCourseDto.FromDomainModel).ToList());
}