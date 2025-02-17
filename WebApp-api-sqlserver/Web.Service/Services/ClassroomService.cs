using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.Service.Services;

public interface IClassRoomService
{
    public Task<IEnumerable<ViewClassroomDto>> GetAllClassrooms();
    public Task<ViewClassroomDto> GetClassroom(string code);
    public Task<ViewClassroomDto> CreateClassroom(CreateClassroomDto dto);
}

public class ClassroomService(IClassroomRepository classroomRepository) : IClassRoomService
{
    public Task<IEnumerable<ViewClassroomDto>> GetAllClassrooms()
    {
        return classroomRepository.GetAllClassrooms();
    }

    public async Task<ViewClassroomDto> GetClassroom(string code)
    {
        var classRoom = await classroomRepository.GetClassroom(code);
        return classRoom;
    }

    public Task<ViewClassroomDto> CreateClassroom(CreateClassroomDto dto)
    {
        return classroomRepository.CreateClassroom(dto);
    }
}