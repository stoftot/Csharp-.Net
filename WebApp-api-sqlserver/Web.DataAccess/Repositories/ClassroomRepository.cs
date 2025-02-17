using Microsoft.Extensions.Configuration;
using Web.DataAccess.Repositories.Abstracts;
using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.DataAccess.Repositories;

public class ClassroomRepository(HttpClient httpClient, IConfiguration configuration) 
    : BaseApiRepository(httpClient, configuration), IClassroomRepository
{
    private string Endpoint { get; } = "ClassRooms";

    public Task<IEnumerable<ViewClassroomDto>> GetAllClassrooms()
    {
        return GetAllAsync<ViewClassroomDto>(Endpoint);
    }

    public Task<ViewClassroomDto?> GetClassroom(string code)
    {
        return GetOneAsync<ViewClassroomDto, string>(Endpoint, code);
    }

    public Task<ViewClassroomDto> CreateClassroom(CreateClassroomDto dto)
    {
        return CreateAsync<ViewClassroomDto,CreateClassroomDto>(Endpoint, dto);
    }
}