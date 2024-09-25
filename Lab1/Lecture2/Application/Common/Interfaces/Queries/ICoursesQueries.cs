using Domain.Courses;

namespace Application.Common.Interfaces.Queries;

public interface ICoursesQueries
{
    Task<IReadOnlyList<Course>> GetAll(CancellationToken cancellationToken);
    
    Task<Course?> GetByName(string name, CancellationToken cancellationToken);
}