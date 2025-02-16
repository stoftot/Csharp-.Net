namespace Web.Api.DTO_s;

public class GetTeacherDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<GetSubjectDto>? Subjects { get; set; }
    public IEnumerable<GetCourseDto>? Courses { get; set; }

    public static GetTeacherDto? ConvertServiceDto(global::Api.Service.DTO_s.GetTeacherDto? dto)
    {
        if (dto == null) return null;
        
        var newDto = new GetTeacherDto
        {
            Id = dto.Id,
            Name = dto.Name
        };
        
        if (dto.Subjects != null)
        {
            newDto.Subjects = dto.Subjects.Select(GetSubjectDto.ConvertServiceDto)!;
        }
        
        if (dto.Courses != null)
        {
            newDto.Courses = dto.Courses.Select(GetCourseDto.ConvertServiceDto)!;
        }

        return newDto;
    }
}

public class CreateTeacherDto
{
    public required string Name { get; set; }

    public global::Api.Service.DTO_s.CreateTeacherDto ConvetToServiceDto()
    {
        return new global::Api.Service.DTO_s.CreateTeacherDto(Name);
    }
}