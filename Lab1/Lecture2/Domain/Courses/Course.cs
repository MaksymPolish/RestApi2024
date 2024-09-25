using Domain.UserCourses;
using Domain.Users;

namespace Domain.Courses;

public class Course
{
    public CourseId Id { get; }

    public string Name { get; private set; }

    public DateTime StartAt { get; private set; }

    public DateTime FinishAt { get; private set; }

    public int MaxStudents { get; private set; }

    public ICollection<UserCourse> EnrolledStudents { get; set; } = new List<UserCourse>();

    public Dictionary<Guid, int> StudentScores { get; private set; } = new();

    public Course(CourseId id, string name, DateTime startAt, DateTime finishAt, int maxStudents)
    {
        Id = id;
        Name = name;
        StartAt = startAt;
        FinishAt = finishAt;
        MaxStudents = maxStudents;
    }

    public static Course New(CourseId id, string name, DateTime startAt, DateTime finishAt, int maxStudents)
        => new(id, name, startAt, finishAt, maxStudents);
}
    
