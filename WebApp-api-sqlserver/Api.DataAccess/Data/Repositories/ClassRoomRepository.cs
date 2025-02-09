using Microsoft.EntityFrameworkCore;
using Web.DataAccess.DTO;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class ClassRoomRepository(UniversityDbContext context)
{
    public async Task<IEnumerable<ClassRoomDTO>> GetAllClassRooms() =>
        await context.ClassRooms
            .Select(c => new ClassRoomDTO()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<ClassRoomDTO> GetClassRoom(string code) =>
        await context.ClassRooms
            .Where(c => c.Code == ClassRoom.NormalizeCode(code))
            .Select(c => new ClassRoomDTO()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .FirstAsync();

    public async Task CreateClassRoom(ClassRoomDTO classRoomDto)
    {
        var classRoom = new ClassRoom
        {
            Code = classRoomDto.Code,
            Capacity = classRoomDto.Capacity
        };

        await context.ClassRooms.AddAsync(classRoom);
        await context.SaveChangesAsync();
    }
}