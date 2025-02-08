using Microsoft.EntityFrameworkCore;
using Web.DataAccess.DTO;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class TeacherRepository(UniversityDbContext context)
{
    public async Task<IEnumerable<TeacherDTO>> GetAllTeachers() =>
        await context.Teachers
            .Select(t => new TeacherDTO { Id = t.Id, Name = t.Name })
            .ToListAsync();

    public async Task<TeacherDTO> GetTeacher(int id) =>
        await context.Teachers
            .Where(t => t.Id == id)
            .Select(t => new TeacherDTO { Id = t.Id, Name = t.Name })
            .FirstAsync();

    public async void CreateTeacher(string name)
    {
        var teacher = new Teacher
        {
            Name = name
        };

        await context.AddAsync(teacher);
        await context.SaveChangesAsync();
    }
}