using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Data.Repositories;
using Web.DataAccess.DTO;

namespace Web.Api.Controllers;

[Route("api/subject")]
[ApiController]

public class SubjectController(SubjectRepository subjectRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = subjectRepository.GetAllSubjects();
        return Ok(subjects);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetSubject([FromRoute] string code)
    {
        var subject = subjectRepository.GetSubject(code);
        return Ok(subject);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDTO dto)
    {
        subjectRepository.CreateSubject(dto);
        return Ok();
    }
}