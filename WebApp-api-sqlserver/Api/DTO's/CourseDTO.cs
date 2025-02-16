namespace Web.Api.DTO_s;

public class GetCourseDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public GetTeacherDto? CourseAdministrator { get; set; }
    public GetTeacherDto? Teacher { get; set; }
    public GetClassroomDto? ClassRoom { get; set; }

    public static GetCourseDto? ConvertServiceDto(global::Api.Service.DTO_s.GetCourseDto? dto)
    {
        if (dto == null) return null;
        return new GetCourseDto
        {
            Code = dto.Code,
            Name = dto.Name,
            Capacity = dto.Capacity,
            CourseAdministrator = GetTeacherDto.ConvertServiceDto(dto.CourseAdministrator),
            Teacher = GetTeacherDto.ConvertServiceDto(dto.Teacher),
            ClassRoom = GetClassroomDto.ConvertServiceDto(dto.ClassRoom)
        };
    }
}

public class CreateCourseDto
{
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public global::Api.Service.DTO_s.CreateCourseDto ConvertToServiceDTO()
    {
        return new global::Api.Service.DTO_s.CreateCourseDto(Name, Capacity);
    }
}