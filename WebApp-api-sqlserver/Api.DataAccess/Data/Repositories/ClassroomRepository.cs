using Api.Service.DTO_s;
using Api.Service.Exceptions;
using Api.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data.Repositories;

public class ClassroomRepository(UniversityDbContext context) : IClassroomRepository
{
    public async Task<IEnumerable<GetClassroomDto>> GetAllClassrooms() =>
        await context.Classrooms
            .Select(c => new GetClassroomDto()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .ToListAsync();
    
    public async Task<GetClassroomDto?> GetClassroom(string code) =>
        await context.Classrooms
            .Where(c => c.Code == Classroom.NormalizeCode(code))
            .Select(c => new GetClassroomDto()
            {
                Code = c.Code,
                Capacity = c.Capacity
            })
            .SingleOrDefaultAsync();

    public async Task<GetClassroomDto> CreateClassroom(CreateClassroomDto classroomDto)
    {
        var classRoom = new Classroom
        {
            Code = classroomDto.Code,
            Capacity = classroomDto.Capacity
        };

        var newClassRoom = await context.Classrooms.AddAsync(classRoom);
        await context.SaveChangesAsync();

        return new GetClassroomDto
        {
            Code = newClassRoom.Entity.Code,
            Capacity = newClassRoom.Entity.Capacity
        };
    }

    public async Task UpdateClassroom(UpdateClassRoomDto dto)
    {
        var currentClassroom = await context.Classrooms
            .Where(c => c.Code == Classroom.NormalizeCode(dto.Code))
            .SingleOrDefaultAsync() 
                               ?? throw new IdentifierDidntMatchAnyEntriesException
                                   ($"There is no class room whit the following code: {dto.Code}", dto.Code);

        currentClassroom.Capacity = dto.Capacity;
        await context.SaveChangesAsync();
    }
}