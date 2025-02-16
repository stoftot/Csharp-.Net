using Api.Service.DTO_s;

namespace Api.Service.Repository.Interfaces;

public interface ISubjectRepository
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects();
    public Task<GetSubjectDTO> GetSubject(string code);
    public Task<GetSubjectDTO> CreateSubject(CreateSubjectDTO dto);
}