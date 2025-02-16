namespace Web.Service.DTO_s;

public class ViewClassRoomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}

public class CreateClassRoomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}