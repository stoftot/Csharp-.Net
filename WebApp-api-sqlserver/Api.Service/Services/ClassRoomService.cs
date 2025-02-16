using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface IClassRoomService
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms();
    public Task<GetClassRoomDTO> GetClassRoom(string code);
    public Task CreateClassRoom(CreateClassRoomDTO dto);
}

public class ClassRoomService(IClassRoomRepository classRoomRepository) : IClassRoomService
{
    public Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms()
    {
        return classRoomRepository.GetAllClassRooms();
    }

    public Task<GetClassRoomDTO> GetClassRoom(string code)
    {
        return classRoomRepository.GetClassRoom(code);
    }

    public Task CreateClassRoom(CreateClassRoomDTO dto)
    {
        return classRoomRepository.CreateClassRoom(dto);
    }
}