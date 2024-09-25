using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CoursesRepository(ApplicationDbContext context): ICoursesRepository, ICoursesQueries
{
    async Task<IReadOnlyList<Course>> ICoursesQueries.GetAll(CancellationToken cancellationToken)
    {
        return await context.Courses.ToListAsync(cancellationToken);
    }
    
    public async Task<Course> Create(Course course, CancellationToken cancellationToken)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync(cancellationToken);
        return course;
    }
    
    public async Task<Course?> GetByName(string name, CancellationToken cancellationToken)
    {
        return await context.Courses.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }

}