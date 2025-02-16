namespace Web.Service.DTO_s;

public class ViewTeacherDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<ViewSubjectDto>? Subjects { get; set; }
    public IEnumerable<ViewCourseDto>? Courses { get; set; }
}

public class CreateTeacherDto
{
    public required string Name { get; set; }
}