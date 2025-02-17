using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.Service.Services;

public interface ITeacherService
{
    public Task<IEnumerable<ViewTeacherDto>> GetAllTeachers();
    public Task<ViewTeacherDto> GetTeacher(int id);
    public Task<ViewTeacherDto> CreateTeacher(CreateTeacherDto dto);
}

public class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
{
    public Task<IEnumerable<ViewTeacherDto>> GetAllTeachers()
    {
        return teacherRepository.GetAllTeachers();
    }

    public async Task<ViewTeacherDto> GetTeacher(int id)
    {
        var teacher = await teacherRepository.GetTeacher(id);
        return teacher;
    }

    public Task<ViewTeacherDto> CreateTeacher(CreateTeacherDto dto)
    {
        return teacherRepository.CreateTeacher(dto);
    }
}