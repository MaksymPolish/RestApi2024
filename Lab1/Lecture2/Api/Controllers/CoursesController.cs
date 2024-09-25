using Api.Dtos;
using Api.Modules.Errors;
using Application.Common.Interfaces.Queries;
using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("courses")]
[ApiController]
public class CoursesController(ISender sender, ICoursesQueries coursesQueries) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(
        [FromBody] CourseDto request,
        CancellationToken cancellationToken)
    {
        var command = new CreateCourseCommand
        {
            Name = request.Name,
            StartAt = request.StartAt,
            FinishAt = request.FinishAt,
            MaxStudents = request.MaxStudents
        };
        
        var result = await sender.Send(command, cancellationToken);

        return result.Match<ActionResult<CourseDto>>(
            course => CourseDto.FromDomainModel(course),
            ex => ex.ToObjectResult());
    }

    [HttpGet]
    public async Task<List<CourseDto>> Get([FromQuery] int courseId, CancellationToken cancellationToken)
    {
        var courses = await coursesQueries.GetAll(cancellationToken);
        return courses.Select(CourseDto.FromDomainModel).ToList();
    }
    
}