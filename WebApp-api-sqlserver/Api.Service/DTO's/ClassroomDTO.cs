namespace Api.Service.DTO_s;

public class GetClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}

public class CreateClassroomDto(string code, int capacity)
{
    public string Code { get; } = code;
    public int Capacity { get; } = capacity;
}