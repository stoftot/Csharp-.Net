using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.Service.Services;

public interface ICourseService
{
    public Task<IEnumerable<ViewCourseDto>> GetAllCourses();
    public Task<ViewCourseDto> GetCourse(string code);
    public Task<ViewCourseDto> CreateCourse(CreateCourseDto dto);
}

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public Task<IEnumerable<ViewCourseDto>> GetAllCourses()
    {
        return courseRepository.GetAllCourses();
    }

    public async Task<ViewCourseDto> GetCourse(string code)
    {
        var course = await courseRepository.GetCourse(code);
        return course;
    }

    public Task<ViewCourseDto> CreateCourse(CreateCourseDto dto)
    {
        return courseRepository.CreateCourse(dto);
    }
}