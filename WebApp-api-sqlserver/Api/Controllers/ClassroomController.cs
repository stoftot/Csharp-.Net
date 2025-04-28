using Api.Service.Exceptions;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;

namespace Web.Api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ClassroomController
    (IClassRoomService classRoomService,
        ILogger<ClassroomController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var classRooms = (await classRoomService.GetAllClassrooms())
            .Select(GetClassroomDto.ConvertServiceDto);
        return Ok(classRooms);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetOne(string code)
    {
        try
        {
            var classRoom = await classRoomService.GetClassroom(code);
            return Ok(GetClassroomDto.ConvertServiceDto(classRoom));
        }
        catch (IdentifierDidntMatchAnyEntriesException e)
        {
            logger.LogError(e, "An error occured while processing GetOne");
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
    public async Task<IActionResult> Create([FromBody] CreateClassroomDto dto)
    {
        var classRoom = dto.ConvertToServiceDto();
        var createdClassRoom = await classRoomService.CreateClassroom(classRoom);
        var newClassRoom = GetClassroomDto.ConvertServiceDto(createdClassRoom)!;
        return CreatedAtAction(nameof(GetOne),new{code = newClassRoom.Code}, newClassRoom);
    }
}