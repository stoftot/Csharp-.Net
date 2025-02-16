using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Web.DataAccess.Repositories.Abstracts;
using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.DataAccess.Repositories;

public class SubjectRepository(HttpClient httpClient, IConfiguration configuration) 
    : BaseApiRepository(httpClient, configuration), ISubjectRepository
{
    private string Endpoint { get; } = "Subjects";

    public Task<IEnumerable<ViewSubjectDto>> GetAllSubjects()
    {
        return GetAllAsync<ViewSubjectDto>(Endpoint);
    }

    public Task<ViewSubjectDto?> GetSubject(string code)
    {
        return GetOneAsync<ViewSubjectDto, string>(Endpoint, code);
    }

    public Task<ViewSubjectDto> CreateSubject(CreateSubjectDto dto)
    {
        return CreateAsync<ViewSubjectDto,CreateSubjectDto>(Endpoint, dto);
    }
}