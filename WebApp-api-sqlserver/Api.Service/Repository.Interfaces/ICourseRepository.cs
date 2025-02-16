using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ICourseRepository
{
    public Task<IEnumerable<GetCourseDTO>> GetAllCourses();
    public Task<GetCourseDTO> GetCourse(string code);
    public Task CreateCourse(CreateCourseDTO dto);
}