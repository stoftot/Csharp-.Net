using Api.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;
using Web.DataAccess.Data.Repositories;

namespace Web.Api.Controllers;

[Route("api/[controller]s")]
[ApiController]

public class SubjectController
    (SubjectRepository subjectRepository,
        ILogger<SubjectController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = (await subjectRepository.GetAllSubjects())
            .Select(GetSubjectDto.ConvertServiceDto);
        return Ok(subjects);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetOne([FromRoute] string code)
    {
        try
        {
            var subject = await subjectRepository.GetSubject(code);
            return Ok(GetSubjectDto.ConvertServiceDto(subject));
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
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto dto)
    {
        var subject = dto.ConvertToServiceDto();
        var createdSubject = await subjectRepository.CreateSubject(subject);
        var newSubject = GetSubjectDto.ConvertServiceDto(createdSubject)!;
        return CreatedAtAction(nameof(GetOne), new { code = newSubject.Code }, newSubject);
    }
}