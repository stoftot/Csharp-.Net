using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ISubjectService
{
    public Task<IEnumerable<GetSubjectDto>> GetAllSubjects();
    public Task<GetSubjectDto> GetSubject(string code);
    public Task<GetSubjectDto> CreateSubject(CreateSubjectDto dto);
}

public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
{
    public Task<IEnumerable<GetSubjectDto>> GetAllSubjects()
    {
        return subjectRepository.GetAllSubjects();
    }

    public async Task<GetSubjectDto> GetSubject(string code)
    {
        try
        {
            var subject = await subjectRepository.GetSubject(code);
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

    public Task<GetSubjectDto> CreateSubject(CreateSubjectDto dto)
    {
        return subjectRepository.CreateSubject(dto);
    }
}