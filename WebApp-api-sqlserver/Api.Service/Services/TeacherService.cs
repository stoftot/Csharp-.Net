using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers();
    public Task<GetTeacherDTO> GetTeacher(int id);
    public Task<GetTeacherDTO> CreateTeacher(CreateTeacherDTO dto);
}

public class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
{
    public Task<IEnumerable<GetTeacherDTO>> GetAllTeachers()
    {
        return teacherRepository.GetAllTeachers();
    }

    public async Task<GetTeacherDTO> GetTeacher(int id)
    {
        try
        {
            var teacher = await teacherRepository.GetTeacher(id);
            if (teacher == null)
                throw new IdentifierDidntMatchAnyEntriesException
                    ($"There is no teacher whit the following id: {id}", $"{id}");
            return teacher!;
        }
        catch (InvalidOperationException e)
        {
            throw new MultipleEntriesWhitSameIdentifierException
                ($"There are multiple teachers whit the following id: {id}", $"{id}", e);
        }
    }

    public Task<GetTeacherDTO> CreateTeacher(CreateTeacherDTO dto)
    {
        return teacherRepository.CreateTeacher(dto);
    }
}