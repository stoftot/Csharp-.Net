using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ISubjectRepository
{
    public Task<IEnumerable<GetSubjectDto>> GetAllSubjects();
    public Task<GetSubjectDto?> GetSubject(string code);
    public Task<GetSubjectDto> CreateSubject(CreateSubjectDto dto);
}