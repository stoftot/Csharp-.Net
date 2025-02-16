using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ITeacherRepository
{
    public Task<IEnumerable<GetTeacherDto>> GetAllTeachers();
    public Task<GetTeacherDto?> GetTeacher(int id);
    public Task<GetTeacherDto> CreateTeacher(CreateTeacherDto dto);
}