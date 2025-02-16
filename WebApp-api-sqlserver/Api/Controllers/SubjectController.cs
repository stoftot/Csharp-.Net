using Api.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;
using Web.DataAccess.Data.Repositories;

namespace Web.Api.Controllers;

[Route("api/[controller]s")]
[ApiController]

public class SubjectController(SubjectRepository subjectRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = (await subjectRepository.GetAllSubjects())
            .Select(GetSubjectDTO.ConvertServiceDTO);
        return Ok(subjects);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetOne([FromRoute] string code)
    {
        try
        {
            var subject = await subjectRepository.GetSubject(code);
            return Ok(GetSubjectDTO.ConvertServiceDTO(subject));
        }
        catch (IdentifierDidntMatchAnyEntriesException e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDTO dto)
    {
        var subject = dto.ConvertToServiceDTO();
        var createdSubject = await subjectRepository.CreateSubject(subject);
        var newSubject = GetSubjectDTO.ConvertServiceDTO(createdSubject)!;
        return CreatedAtAction(nameof(GetOne), new { code = newSubject.Code }, newSubject);
    }
}