using Api.Service.Exceptions;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Api.DTO_s;

namespace Web.Api.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ClassRoomController
    (IClassRoomService classRoomService,
        ILogger<ClassRoomController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var classRooms = (await classRoomService.GetAllClassRooms())
            .Select(GetClassRoomDTO.ConvertServiceDTO);
        return Ok(classRooms);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetOne(string code)
    {
        try
        {
            var classRoom = await classRoomService.GetClassRoom(code);
            return Ok(GetClassRoomDTO.ConvertServiceDTO(classRoom));
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
    public async Task<IActionResult> Create([FromBody] CreateClassRoomDTO dto)
    {
        var classRoom = dto.ConvertToServiceDTO();
        var createdClassRoom = await classRoomService.CreateClassRoom(classRoom);
        var newClassRoom = GetClassRoomDTO.ConvertServiceDTO(createdClassRoom)!;
        return CreatedAtAction(nameof(GetOne),new{code = newClassRoom.Code}, newClassRoom);
    }
}