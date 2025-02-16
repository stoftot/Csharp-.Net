namespace Web.Service.DTO_s;

public class ViewClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}

public class CreateClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}