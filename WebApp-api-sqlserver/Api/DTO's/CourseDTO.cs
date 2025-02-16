namespace Web.Api.DTO_s;

public class GetCourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public GetTeacherDTO? CourseAdministrator { get; set; }
    public GetTeacherDTO? Teacher { get; set; }
    public GetClassRoomDTO? ClassRoom { get; set; }
}

public class CreateCourseDTO(string name, int capacity)
{
    public required string Name { get; set; } = name;
    public required int Capacity { get; set; } = capacity;
}