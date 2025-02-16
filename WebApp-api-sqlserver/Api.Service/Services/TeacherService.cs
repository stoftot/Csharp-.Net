using Api.Service.DTO_s;

namespace Api.Service.Services;

public interface ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers();
    public Task<GetTeacherDTO> GetTeacher(int id);
    public Task CreateTeacher(CreateTeacherDTO dto);
}

public class TeacherService : ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers()
    {
        throw new NotImplementedException();
    }

    public Task<GetTeacherDTO> GetTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateTeacher(CreateTeacherDTO dto)
    {
        throw new NotImplementedException();
    }
}