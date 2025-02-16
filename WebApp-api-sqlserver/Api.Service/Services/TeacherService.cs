using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;

namespace Api.Service.Services;

public interface ITeacherService
{
    public Task<IEnumerable<GetTeacherDto>> GetAllTeachers();
    public Task<GetTeacherDto> GetTeacher(int id);
    public Task<GetTeacherDto> CreateTeacher(CreateTeacherDto dto);
}

public class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
{
    public Task<IEnumerable<GetTeacherDto>> GetAllTeachers()
    {
        return teacherRepository.GetAllTeachers();
    }

    public async Task<GetTeacherDto> GetTeacher(int id)
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

    public Task<GetTeacherDto> CreateTeacher(CreateTeacherDto dto)
    {
        return teacherRepository.CreateTeacher(dto);
    }
}