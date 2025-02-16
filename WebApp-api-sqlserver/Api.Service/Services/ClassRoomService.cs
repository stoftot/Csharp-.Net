using Api.Service.DTO_s;

namespace Api.Service.Services;

public interface IClassRoomService
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms();
    public Task<GetClassRoomDTO> GetClassRoom(string code);
    public Task CreateClassRoom(CreateClassRoomDTO dto);
}

public class ClassRoomService : IClassRoomService
{
    public async Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms()
    {
        throw new NotImplementedException();
    }

    public async Task<GetClassRoomDTO> GetClassRoom(string code)
    {
        throw new NotImplementedException();
    }

    public async Task CreateClassRoom(CreateClassRoomDTO dto)
    {
        throw new NotImplementedException();
    }
}