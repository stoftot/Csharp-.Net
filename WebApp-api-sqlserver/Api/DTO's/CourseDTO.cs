﻿namespace Web.Api.DTO_s;

public class GetCourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public GetTeacherDTO? CourseAdministrator { get; set; }
    public GetTeacherDTO? Teacher { get; set; }
    public GetClassRoomDTO? ClassRoom { get; set; }

    public static GetCourseDTO? ConvertServiceDTO(global::Api.Service.DTO_s.GetCourseDTO? dto)
    {
        if (dto == null) return null;
        return new GetCourseDTO
        {
            Code = dto.Code,
            Name = dto.Name,
            Capacity = dto.Capacity,
            CourseAdministrator = GetTeacherDTO.ConvertServiceDTO(dto.CourseAdministrator),
            Teacher = GetTeacherDTO.ConvertServiceDTO(dto.Teacher),
            ClassRoom = GetClassRoomDTO.ConvertServiceDTO(dto.ClassRoom)
        };
    }
}

public class CreateCourseDTO(string name, int capacity)
{
    public required string Name { get; set; } = name;
    public required int Capacity { get; set; } = capacity;
}