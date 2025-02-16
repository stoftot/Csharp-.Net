namespace Api.Service.DTO_s;

public class GetTeacherDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<GetSubjectDTO>? Subjects { get; set; }
    public IEnumerable<GetCourseDTO>? Courses { get; set; }
}

public class CreateTeacherDTO(string name)
{
    public string Name { get; } = name;
}