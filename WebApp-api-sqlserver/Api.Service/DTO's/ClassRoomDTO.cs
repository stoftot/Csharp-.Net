namespace Api.Service.DTO_s;

public class GetClassRoomDTO
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}

public class CreateClassRoomDTO
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }
}