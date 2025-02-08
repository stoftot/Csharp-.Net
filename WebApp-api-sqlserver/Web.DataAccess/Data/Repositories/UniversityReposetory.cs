using Microsoft.EntityFrameworkCore;
using Web.Api.Data;
using Web.Api.DTO;
using Web.Api.Models;

namespace Web.Api.Repositories;

public class UniversityRepository(UniversityDbContext context)
{
    private readonly UniversityDbContext context = context;

    //Subject
    public async Task<IEnumerable<SubjectDTO>> GetAllSubjects() =>
        await context.Subjects
            .Select(s => new SubjectDTO { Code = s.Code, Name = s.Name })
            .ToListAsync();
    
    //ClassRoom
    public async Task<IEnumerable<ClassRoomDTO>> GetAllClassRooms() =>
        await context.ClassRooms
            .Select(c => new ClassRoomDTO()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .ToListAsync();
}