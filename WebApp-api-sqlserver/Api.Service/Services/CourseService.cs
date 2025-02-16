using Api.Service.DTO_s;

namespace Api.Service.Services;

public interface ICourseService
{
    public Task<IEnumerable<GetCourseDTO>> GetAllCourses();
    public Task<GetCourseDTO> GetCourse(string code);
    public Task CreateCourse(CreateCourseDTO dto);
}

public class CourseService : ICourseService
{
    public Task<IEnumerable<GetCourseDTO>> GetAllCourses()
    {
        throw new NotImplementedException();
    }

    public Task<GetCourseDTO> GetCourse(string code)
    {
        throw new NotImplementedException();
    }

    public Task CreateCourse(CreateCourseDTO dto)
    {
        throw new NotImplementedException();
    }
}