using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects();
    public Task<GetSubjectDTO> GetSubject(string code);
    public Task<GetSubjectDTO> CreateSubject(CreateSubjectDTO dto);
}

public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
{
    public Task<IEnumerable<GetSubjectDTO>> GetAllSubjects()
    {
        return subjectRepository.GetAllSubjects();
    }

    public Task<GetSubjectDTO> GetSubject(string code)
    {
        try
        {
            var subject = subjectRepository.GetSubject(code);
            if (subject == null)
                throw new IdentifierDidntMatchAnyEntriesException
                    ($"There is no subject whit the following code: {code}", code);
            return subject!;
        }
        catch (InvalidOperationException e)
        {
            throw new MultipleEntriesWhitSameIdentifierException
                ($"There are multiple subjects whit the following code: {code}", code, e);
        }
    }

    public Task<GetSubjectDTO> CreateSubject(CreateSubjectDTO dto)
    {
        return subjectRepository.CreateSubject(dto);
    }
}