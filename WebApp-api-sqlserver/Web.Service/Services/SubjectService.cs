using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.Service.Services;

public interface ISubjectService
{
    public Task<IEnumerable<ViewSubjectDto>> GetAllSubjects();
    public Task<ViewSubjectDto> GetSubject(string code);
    public Task<ViewSubjectDto> CreateSubject(CreateSubjectDto dto);
}

public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
{
    public Task<IEnumerable<ViewSubjectDto>> GetAllSubjects()
    {
        return subjectRepository.GetAllSubjects();
    }

    public async Task<ViewSubjectDto> GetSubject(string code)
    {
        var subject = await subjectRepository.GetSubject(code);
        return subject;
    }

    public Task<ViewSubjectDto> CreateSubject(CreateSubjectDto dto)
    {
        return subjectRepository.CreateSubject(dto);
    }
}