using Microsoft.Extensions.Configuration;
using Web.DataAccess.Repositories.Abstracts;
using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.DataAccess.Repositories;

public class CourseRepository(HttpClient httpClient, IConfiguration configuration) 
    : BaseApiRepository(httpClient, configuration), ICourseRepository
{
    private string Endpoint { get; } = "Courses";

    public Task<IEnumerable<ViewCourseDto>> GetAllCourses()
    {
        return GetAllAsync<ViewCourseDto>(Endpoint);
    }

    public Task<ViewCourseDto> GetCourse(string code)
    {
        return GetOneAsync<ViewCourseDto, string>(Endpoint, code);
    }

    public Task<ViewCourseDto> CreateCourse(CreateCourseDto dto)
    {
        return CreateAsync<ViewCourseDto,CreateCourseDto>(Endpoint, dto);
    }
}