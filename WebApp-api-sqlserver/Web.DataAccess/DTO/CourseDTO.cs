namespace Web.Api.DTO;

public class CourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }
    
    public required TeacherDTO CourseAdminestre { get; set; }
    public required TeacherDTO Teacher { get; set; }
    public required ClassRoomDTO ClassRoom { get; set; }
}