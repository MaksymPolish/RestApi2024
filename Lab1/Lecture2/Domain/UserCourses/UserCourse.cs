using Domain.Courses;
using Domain.Users;

namespace Domain.UserCourses;

public class UserCourse
{
    public UserCourseId Id { get; }

    public UserId UserId { get; set; }
    public User? User { get; set; }

    public CourseId CourseId { get; set; }
    public Course? Course { get; set; }

    public DateTime EnrollmentDate { get; set; }
}