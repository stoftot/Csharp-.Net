using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class SubjectRepository(UniversityDbContext context) : ISubjectRepository
{
    public async Task<IEnumerable<GetSubjectDto>> GetAllSubjects() =>
        await context.Subjects
            .Select(s => new GetSubjectDto { Code = s.Code, Name = s.Name })
            .ToListAsync();

    public async Task<GetSubjectDto?> GetSubject(string code) =>
        await context.Subjects
            .Where(s => s.Code == Subject.NormalizeCode(code))
            .Select(s => new GetSubjectDto { Code = s.Code, Name = s.Name })
            .SingleOrDefaultAsync();

    public async Task<GetSubjectDto> CreateSubject(CreateSubjectDto dto)
    {
        var subject = new Subject
        {
            Code = dto.Code,
            Name = dto.Name
        };

        var newSubject = await context.Subjects.AddAsync(subject);
        await context.SaveChangesAsync();

        return new GetSubjectDto
        {
            Code = newSubject.Entity.Code,
            Name = newSubject.Entity.Name
        };
    }
}