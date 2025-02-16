using Api.Service.DTO_s;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class ClassRoomRepository(UniversityDbContext context) : IClassRoomRepository
{
    public async Task<IEnumerable<GetClassRoomDTO>> GetAllClassRooms() =>
        await context.ClassRooms
            .Select(c => new GetClassRoomDTO()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<GetClassRoomDTO> GetClassRoom(string code) =>
        await context.ClassRooms
            .Where(c => c.Code == ClassRoom.NormalizeCode(code))
            .Select(c => new GetClassRoomDTO()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .FirstAsync();

    public async Task<GetClassRoomDTO> CreateClassRoom(CreateClassRoomDTO classRoomDto)
    {
        var classRoom = new ClassRoom
        {
            Code = classRoomDto.Code,
            Capacity = classRoomDto.Capacity
        };

        var newClassRoom = await context.ClassRooms.AddAsync(classRoom);
        await context.SaveChangesAsync();

        return new GetClassRoomDTO
        {
            Code = newClassRoom.Entity.Code,
            Capacity = newClassRoom.Entity.Capacity
        };
    }
}