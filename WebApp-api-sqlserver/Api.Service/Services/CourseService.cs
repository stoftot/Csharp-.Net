using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ICourseService
{
    public Task<IEnumerable<GetCourseDto>> GetAllCourses();
    public Task<GetCourseDto> GetCourse(string code);
    public Task<GetCourseDto> CreateCourse(CreateCourseDto dto);
}

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public Task<IEnumerable<GetCourseDto>> GetAllCourses()
    {
        return courseRepository.GetAllCourses();
    }

    public async Task<GetCourseDto> GetCourse(string code)
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

    public Task<GetCourseDto> CreateCourse(CreateCourseDto dto)
    {
        return courseRepository.CreateCourse(dto);
    }
}