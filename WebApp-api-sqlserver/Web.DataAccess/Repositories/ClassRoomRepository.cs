using Microsoft.Extensions.Configuration;
using Web.DataAccess.Repositories.Abstracts;
using Web.Service.DTO_s;
using Web.Service.Repository.Interfaces;

namespace Web.DataAccess.Repositories;

public class ClassRoomRepository(HttpClient httpClient, IConfiguration configuration) 
    : BaseApiRepository(httpClient, configuration), IClassRoomRepository
{
    private string Endpoint { get; } = "ClassRooms";

    public Task<IEnumerable<ViewClassRoomDto>> GetAllClassRooms()
    {
        return GetAllAsync<ViewClassRoomDto>(Endpoint);
    }

    public Task<ViewClassRoomDto?> GetClassRoom(string code)
    {
        return GetOneAsync<ViewClassRoomDto, string>(Endpoint, code);
    }

    public Task<ViewClassRoomDto> CreateClassRoom(CreateClassRoomDto dto)
    {
        return CreateAsync<ViewClassRoomDto,CreateClassRoomDto>(Endpoint, dto);
    }
}