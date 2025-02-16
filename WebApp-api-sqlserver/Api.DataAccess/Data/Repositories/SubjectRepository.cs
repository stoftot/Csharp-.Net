using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class SubjectRepository(UniversityDbContext context) : ISubjectRepository
{
    public async Task<IEnumerable<GetSubjectDTO>> GetAllSubjects() =>
        await context.Subjects
            .Select(s => new GetSubjectDTO { Code = s.Code, Name = s.Name })
            .ToListAsync();

    public async Task<GetSubjectDTO> GetSubject(string code) =>
        await context.Subjects
            .Where(s => s.Code == Subject.NormalizeCode(code))
            .Select(s => new GetSubjectDTO { Code = s.Code, Name = s.Name })
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