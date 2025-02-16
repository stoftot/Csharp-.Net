using Api.Service.Exceptions;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;

namespace Web.Api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class CourseController(ICourseService courseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = (await courseService.GetAllCourses())
            .Select(GetCourseDTO.ConvertServiceDTO);
        return Ok(courses);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetOne(string code)
    {
        try
        {
            var course = await courseService.GetCourse(code);
            return Ok(GetCourseDTO.ConvertServiceDTO(course));
        }
        catch (IdentifierDidntMatchAnyEntriesException e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseDTO dto)
    {
        var course = dto.ConvertToServiceDTO();
        var createdCourse = await courseService.CreateCourse(course);
        var newCourse = GetCourseDTO.ConvertServiceDTO(createdCourse)!;
        return CreatedAtAction(nameof(GetOne), new { code = newCourse.Code }, newCourse);
    }
}