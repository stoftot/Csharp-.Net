using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ITeacherRepository
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers();
    public Task<GetTeacherDTO> GetTeacher(int id);
    public Task<GetTeacherDTO> CreateTeacher(CreateTeacherDTO dto);
}