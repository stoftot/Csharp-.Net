using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface IClassRoomRepository
{
    public Task<IEnumerable<GetClassRoomDto>> GetAllClassRooms();
    public Task<GetClassRoomDto?> GetClassRoom(string code);
    public Task<GetClassRoomDto> CreateClassRoom(CreateClassRoomDto dto);
}