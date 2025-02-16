using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class TeacherRepository(UniversityDbContext context) : ITeacherRepository
{
    public async Task<IEnumerable<GetTeacherDTO>> GetAllTeachers() =>
        await context.Teachers
            .Select(t => new GetTeacherDTO { Id = t.Id, Name = t.Name })
            .ToListAsync();

    public async Task<GetTeacherDTO> GetTeacher(int id) =>
        await context.Teachers
            .Where(t => t.Id == id)
            .Select(t => new GetTeacherDTO { Id = t.Id, Name = t.Name })
            .FirstAsync();

    public async Task<GetTeacherDTO>CreateTeacher(CreateTeacherDTO dto)
    {
        var teacher = new Teacher
        {
            Name = dto.Name
        };

        var newTeacher = await context.AddAsync(teacher);
        await context.SaveChangesAsync();
        
        return new GetTeacherDTO
        {
            Id = newTeacher.Entity.Id,
            Name = newTeacher.Entity.Name
        };
    }
}