using Web.Service.DTO_s;

namespace Web.Service.Repository.Interfaces;

public interface ITeacherRepository
{
    public Task<IEnumerable<ViewTeacherDto>> GetAllTeachers();
    public Task<ViewTeacherDto?> GetTeacher(int id);
    public Task<ViewTeacherDto> CreateTeacher(CreateTeacherDto dto);
}