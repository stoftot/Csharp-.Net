using Api.Service.DTO_s;

namespace Api.Service.Services;

public interface ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers();
    public Task<GetTeacherDTO> GetTeacher(int id);
    public Task CreateTeacher(CreateTeacherDTO dto);
}

public class TeacherService(ITeacherService teacherService) : ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers()
    {
        return teacherService.GetAllTeachers();
    }

    public Task<GetTeacherDTO> GetTeacher(int id)
    {
        return teacherService.GetTeacher(id);
    }

    public Task CreateTeacher(CreateTeacherDTO dto)
    {
        return teacherService.CreateTeacher(dto);
    }
}