namespace Web.Api.DTO_s;

public class GetTeacherDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<GetSubjectDTO>? Subjects { get; set; }
    public IEnumerable<GetCourseDTO>? Courses { get; set; }

    public static GetTeacherDTO? ConvertServiceDTO(global::Api.Service.DTO_s.GetTeacherDTO? dto)
    {
        if (dto == null) return null;
        
        var newDto = new GetTeacherDTO
        {
            Id = dto.Id,
            Name = dto.Name
        };
        
        if (dto.Subjects != null)
        {
            newDto.Subjects = dto.Subjects.Select(GetSubjectDTO.ConvertServiceDTO)!;
        }
        
        if (dto.Courses != null)
        {
            newDto.Courses = dto.Courses.Select(GetCourseDTO.ConvertServiceDTO)!;
        }

        return newDto;
    }
}

public class CreateTeacherDTO
{
    public required string Name { get; set; }
}