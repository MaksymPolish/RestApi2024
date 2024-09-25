using Domain.UserCourses;
using Domain.Users;
using Domain.Courses;

namespace Api.Dtos;

public record UserCourseDto(
    Guid? Id,
    Guid UserId,
    UserDto? User,
    Guid CourseId,
    CourseDto? Course,
    DateTime EnrollmentDate)
{
    public static UserCourseDto FromDomainModel(UserCourse userCourse)
        => new(
            Id: userCourse.Id.Value,
            UserId: userCourse.UserId.Value,
            User: userCourse.User == null ? null : UserDto.FromDomainModel(userCourse.User),
            CourseId: userCourse.CourseId.Value,
            Course: userCourse.Course == null ? null : CourseDto.FromDomainModel(userCourse.Course),
            EnrollmentDate: userCourse.EnrollmentDate);
}