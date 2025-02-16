using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Web.DataAccess.Repositories.Abstracts;
using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.DataAccess.Repositories;

public class TeacherApiRepository(HttpClient httpClient, IConfiguration configuration) 
    : BaseApiRepository(httpClient, configuration), ITeacherRepository
{
    private string Endpoint { get; } = "Teachers";

    public Task<IEnumerable<ViewTeacherDto>> GetAllTeachers()
    {
        return GetAllAsync<ViewTeacherDto>(Endpoint);
    }

    public Task<ViewTeacherDto?> GetTeacher(int id)
    {
        return GetOneAsync<ViewTeacherDto, int>(Endpoint, id);
    }

    public Task<ViewTeacherDto> CreateTeacher(CreateTeacherDto dto)
    {
        return CreateAsync<ViewTeacherDto,CreateTeacherDto>(Endpoint, dto);
    }
}