namespace Web.Service.DTO_s;

public class ViewClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}

public class CreateClassroomDto(string code, int capacity)
{
    public string Code { get; } = code;
    public int Capacity { get; } = capacity;
}

public class UpdateClassroomDto(int capacity)
{
    public int Capacity { get; } = capacity;
}