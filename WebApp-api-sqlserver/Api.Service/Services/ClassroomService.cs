using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface IClassRoomService
{
    public Task<IEnumerable<GetClassroomDto>> GetAllClassrooms();
    public Task<GetClassroomDto> GetClassroom(string code);
    public Task<GetClassroomDto> CreateClassroom(CreateClassroomDto dto);
}

public class ClassroomService(IClassroomRepository classroomRepository) : IClassRoomService
{
    public Task<IEnumerable<GetClassroomDto>> GetAllClassrooms()
    {
        return classroomRepository.GetAllClassrooms();
    }

    public async Task<GetClassroomDto> GetClassroom(string code)
    {
        try
        {
            var classRoom = await classroomRepository.GetClassroom(code);
            if (classRoom == null)
                throw new IdentifierDidntMatchAnyEntriesException
                    ($"There is no class room whit the following code: {code}", code);
            return classRoom!;
        }
        catch (InvalidOperationException e)
        {
            throw new MultipleEntriesWhitSameIdentifierException
                ($"There are multiple class rooms whit the following code: {code}", code, e);
        }
    }

    public Task<GetClassroomDto> CreateClassroom(CreateClassroomDto dto)
    {
        return classroomRepository.CreateClassroom(dto);
    }
}