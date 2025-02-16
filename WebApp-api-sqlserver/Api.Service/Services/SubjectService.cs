using Api.Service.DTO_s;

namespace Api.Service.Services;

public interface ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects();
    public Task<GetSubjectDTO> GetSubject(string code);
    public Task CreateSubject(CreateSubjectDTO dto);
}

public class SubjectService : ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects()
    {
        throw new NotImplementedException();
    }

    public Task<GetSubjectDTO> GetSubject(string code)
    {
        throw new NotImplementedException();
    }

    public Task CreateSubject(CreateSubjectDTO dto)
    {
        throw new NotImplementedException();
    }
}