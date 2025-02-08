using Microsoft.EntityFrameworkCore;
using Web.DataAccess.DTO;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class CourseRepository(UniversityDbContext context)
{
    public async Task<IEnumerable<CourseDTO>> GetAllCourses() =>
        await context.Courses
            .Select(c => new CourseDTO
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<CourseDTO> GetCourse(string code) =>
        await context.Courses
            .Where(c => c.Code == Course.NormalizeCode(code))
            .Select(c => new CourseDTO
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .FirstAsync();

    public async void CreateCourse(CourseDTO courseDto)
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