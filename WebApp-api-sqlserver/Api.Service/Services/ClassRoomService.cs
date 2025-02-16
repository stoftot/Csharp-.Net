using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface IClassRoomService
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms();
    public Task<GetClassRoomDTO> GetClassRoom(string code);
    public Task<GetClassRoomDTO> CreateClassRoom(CreateClassRoomDTO dto);
}

public class ClassRoomService(IClassRoomRepository classRoomRepository) : IClassRoomService
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms()
    {
        return classRoomRepository.GetAllClassRooms();
    }

    public async Task<GetClassRoomDTO> GetClassRoom(string code)
    {
        try
        {
            var classRoom = await classRoomRepository.GetClassRoom(code);
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

    public Task<GetClassRoomDTO> CreateClassRoom(CreateClassRoomDTO dto)
    {
        return classRoomRepository.CreateClassRoom(dto);
    }
}