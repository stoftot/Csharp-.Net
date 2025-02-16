using Web.Service.DTO_s;

namespace Web.Service.Repository.Interfaces;

public interface IClassRoomRepository
{
    public Task<IEnumerable<ViewClassRoomDto>> GetAllClassRooms();
    public Task<ViewClassRoomDto?> GetClassRoom(string code);
    public Task<ViewClassRoomDto> CreateClassRoom(CreateClassRoomDto dto);
}