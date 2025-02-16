namespace Web.Service.DTO_s;

public class ViewCourseDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public ViewTeacherDto? CourseAdministrator { get; set; }
    public ViewTeacherDto? Teacher { get; set; }
    public ViewClassroomDto? ClassRoom { get; set; }
}

public class CreateCourseDto
{
    public required string Name { get; set; }
    public required int Capacity { get; set; }
}