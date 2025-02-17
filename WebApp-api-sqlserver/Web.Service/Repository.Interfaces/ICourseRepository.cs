using Web.Service.DTO_s;

namespace Web.Service.Repository.Interfaces;

public interface ICourseRepository
{
    public Task<IEnumerable<ViewCourseDto>> GetAllCourses();
    public Task<ViewCourseDto> GetCourse(string code);
    public Task<ViewCourseDto> CreateCourse(CreateCourseDto dto);
}