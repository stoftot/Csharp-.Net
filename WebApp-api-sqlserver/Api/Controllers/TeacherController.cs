using Api.Service.Exceptions;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;

namespace Web.Api.Controllers;
[Route("api/[controller]s")]
[ApiController]
public class TeacherController
    (ITeacherService teacherService,
        ILogger<TeacherController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = (await teacherService.GetAllTeachers())
            .Select(GetTeacherDTO.ConvertServiceDTO);
        return Ok(teachers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOne(int id)
    {
        try
        {
            var teacher = await teacherService.GetTeacher(id);
            return Ok(GetTeacherDTO.ConvertServiceDTO(teacher));
        }
        catch (IdentifierDidntMatchAnyEntriesException e)
        {
            return NotFound();
        }
        catch (MultipleEntriesWhitSameIdentifierException e)
        {
            logger.LogError(e, "An error occured while processing GetOne");
            return Problem(
                detail: "The service is temporarily unavailable. Please try again later.",
                statusCode: 503,
                title: "Service Unavailable"
            );
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherDTO dto)
    {
        var createdTeacher = await teacherService.CreateTeacher(dto.ConvetToServiceDTO());
        var newTeacher = GetTeacherDTO.ConvertServiceDTO(createdTeacher)!;
        return CreatedAtAction(nameof(GetOne), new { id = newTeacher.Id }, newTeacher);
    }
}