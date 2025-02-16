namespace Api.Service.DTO_s;

public class GetTeacherDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<GetSubjectDto>? Subjects { get; set; }
    public IEnumerable<GetCourseDto>? Courses { get; set; }
}

public class CreateTeacherDto(string name)
{
    public string Name { get; } = name;
}