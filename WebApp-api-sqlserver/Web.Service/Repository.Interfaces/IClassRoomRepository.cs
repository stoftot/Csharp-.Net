using Web.Service.DTO_s;

namespace Web.Service.Repository.Interfaces;

public interface IClassRoomRepository
{
    public Task<IEnumerable<ViewClassroomDto>> GetAllClassrooms();
    public Task<ViewClassroomDto?> GetClassroom(string code);
    public Task<ViewClassroomDto> CreateClassroom(CreateClassroomDto dto);
}