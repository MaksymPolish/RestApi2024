using Domain.Courses;

namespace Application.Common.Interfaces.Repositories;

public interface ICoursesRepository
{
    Task<Course> Create(Course course, CancellationToken cancellationToken);
    
}