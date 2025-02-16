using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class CourseRepository(UniversityDbContext context) : ICourseRepository
{
    public async Task<IEnumerable<GetCourseDto>> GetAllCourses() =>
        await context.Courses
            .Select(c => new GetCourseDto
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<GetCourseDto?> GetCourse(string code) =>
        await context.Courses
            .Where(c => c.Code == Course.NormalizeCode(code))
            .Select(c => new GetCourseDto
            {
                Code = c.Code,
                Name = c.Name,
                Capacity = c.Capacity
            })
            .SingleOrDefaultAsync();

    public async Task<GetCourseDto> CreateCourse(CreateCourseDto courseDto)
    {
        var course = new Course
        {
            Code = courseDto.Code,
            Name = courseDto.Name,
            Capacity = courseDto.Capacity
        };

        var newCourse = await context.AddAsync(course);
        await context.SaveChangesAsync();

        return new GetCourseDto
        {
            Code = newCourse.Entity.Code,
            Name = newCourse.Entity.Name,
            Capacity = newCourse.Entity.Capacity
        };
    }
}