using Application.Common.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("user_courses")]
[ApiController]
public class UserCoursesController(ISender sender, IUserCoursesQueries userCoursesQueries) : ControllerBase
{
    
}