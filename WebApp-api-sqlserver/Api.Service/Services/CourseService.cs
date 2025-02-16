using Api.Service.DTO_s;
using Api.Service.Exceptions;
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

    public async Task<GetCourseDTO> GetCourse(string code)
    {
        try
        {
            var course = await courseRepository.GetCourse(code);
            if (course == null)
                throw new IdentifierDidntMatchAnyEntriesException
                    ($"There is no course whit the following code: {code}", code);
            return course!;
        }
        catch (InvalidOperationException e)
        {
            throw new MultipleEntriesWhitSameIdentifierException
                ($"There are multiple courses whit the following code: {code}", code, e);
        }
    }

    public Task<GetCourseDTO> CreateCourse(CreateCourseDTO dto)
    {
        return courseRepository.CreateCourse(dto);
    }
}