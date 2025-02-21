using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface IClassroomRepository
{
    public Task<IEnumerable<GetClassroomDto>> GetAllClassrooms();
    public Task<GetClassroomDto?> GetClassroom(string code);
    public Task<GetClassroomDto> CreateClassroom(CreateClassroomDto dto);
    public Task UpdateClassroom(UpdateClassRoomDto dto);
    public Task DeleteClassroom(string code);
}