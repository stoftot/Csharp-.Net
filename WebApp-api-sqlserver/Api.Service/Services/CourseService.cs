using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ICourseService
{
    public Task<IEnumerable<GetCourseDTO>> GetAllCourses();
    public Task<GetCourseDTO> GetCourse(string code);
    public Task<GetCourseDTO> CreateCourse(CreateCourseDTO dto);
}

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public Task<IEnumerable<GetCourseDTO>> GetAllCourses()
    {
        return courseRepository.GetAllCourses();
    }

    public Task<GetCourseDTO> GetCourse(string code)
    {
        return courseRepository.GetCourse(code);
    }

    public Task<GetCourseDTO> CreateCourse(CreateCourseDTO dto)
    {
        return courseRepository.CreateCourse(dto);
    }
}