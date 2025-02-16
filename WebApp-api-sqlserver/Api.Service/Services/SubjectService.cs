using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects();
    public Task<GetSubjectDTO> GetSubject(string code);
    public Task CreateSubject(CreateSubjectDTO dto);
}

public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects()
    {
        return subjectRepository.GetAllSubjects();
    }

    public Task<GetSubjectDTO> GetSubject(string code)
    {
        return subjectRepository.GetSubject(code);
    }

    public Task CreateSubject(CreateSubjectDTO dto)
    {
        return subjectRepository.CreateSubject(dto);
    }
}