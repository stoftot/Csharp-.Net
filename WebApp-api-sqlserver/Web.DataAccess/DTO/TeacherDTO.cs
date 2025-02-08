namespace Web.Api.DTO;

public class TeacherDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<SubjectDTO> Subjects { get; set; }
    public required IEnumerable<CourseDTO> Courses { get; set; }
}