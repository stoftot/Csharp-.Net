using Microsoft.EntityFrameworkCore;
using Web.DataAccess.DTO;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class SubjectRepository(UniversityDbContext context)
{
    public async Task<IEnumerable<SubjectDTO>> GetAllSubjects() =>
        await context.Subjects
            .Select(s => new SubjectDTO { Code = s.Code, Name = s.Name })
            .ToListAsync();

    public async Task<SubjectDTO> GetSubject(string code) =>
        await context.Subjects
            .Where(s => s.Code == Subject.NormalizeCode(code))
            .Select(s => new SubjectDTO { Code = s.Code, Name = s.Name })
            .FirstAsync();

    public async Task CreateSubject(CreateSubjectDTO dto)
    {
        var subject = new Subject
        {
            Code = dto.Code,
            Name = dto.Name
        };

        await context.Subjects.AddAsync(subject);
        await context.SaveChangesAsync();
    }
}