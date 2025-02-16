using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ICourseRepository
{
    public Task<IEnumerable<GetCourseDto>> GetAllCourses();
    public Task<GetCourseDto?> GetCourse(string code);
    public Task<GetCourseDto> CreateCourse(CreateCourseDto dto);
}