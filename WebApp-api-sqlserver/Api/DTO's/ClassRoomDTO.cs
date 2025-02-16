namespace Web.Api.DTO_s;

public class GetClassRoomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }

    public static GetClassRoomDto? ConvertServiceDto(global::Api.Service.DTO_s.GetClassRoomDto? dto)
    {
        if (dto == null) return null;
        return new GetClassRoomDto
        {
            Code = dto.Code,
            Capacity = dto.Capacity
        };
    }
}

public class CreateClassRoomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }

    public global::Api.Service.DTO_s.CreateClassRoomDto ConvertToServiceDto()
    {
        return new global::Api.Service.DTO_s.CreateClassRoomDto(Code, Capacity);
    }
}