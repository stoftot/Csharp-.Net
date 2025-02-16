using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class CourseRepository(UniversityDbContext context) : ICourseRepository
{
    public async Task<IEnumerable<GetCourseDTO>> GetAllCourses() =>
        await context.Courses
            .Select(c => new GetCourseDTO
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<GetCourseDTO> GetCourse(string code) =>
        await context.Courses
            .Where(c => c.Code == Course.NormalizeCode(code))
            .Select(c => new GetCourseDTO
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .FirstAsync();

    public async Task CreateCourse(CreateCourseDTO courseDto)
    {
        var course = new Course
        {
            Code = courseDto.Code,
            Name = courseDto.Name,
            Capacity = courseDto.Capacity
        };

        await context.AddAsync(course);
        await context.SaveChangesAsync();
    }
}