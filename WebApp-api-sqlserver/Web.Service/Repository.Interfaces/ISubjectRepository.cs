using Web.Service.DTO_s;

namespace Web.Service.Repository.Interfaces;

public interface ISubjectRepository
{
    public Task<IEnumerable<ViewSubjectDto>> GetAllSubjects();
    public Task<ViewSubjectDto?> GetSubject(string code);
    public Task<ViewSubjectDto> CreateSubject(CreateSubjectDto dto);
}