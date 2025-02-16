using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface IClassRoomRepository
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms();
    public Task<GetClassRoomDTO?> GetClassRoom(string code);
    public Task<GetClassRoomDTO> CreateClassRoom(CreateClassRoomDTO dto);
}