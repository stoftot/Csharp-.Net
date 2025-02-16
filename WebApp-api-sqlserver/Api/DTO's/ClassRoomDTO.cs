namespace Web.Api.DTO_s;

public class GetClassRoomDTO
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }

    public static GetClassRoomDTO? ConvertServiceDTO(global::Api.Service.DTO_s.GetClassRoomDTO? dto)
    {
        if (dto == null) return null;
        return new GetClassRoomDTO
        {
            Code = dto.Code,
            Capacity = dto.Capacity
        };
    }
}

public class CreateClassRoomDTO
{
    public string Code { get; set; }
    public int Capacity { get; set; }

    public global::Api.Service.DTO_s.CreateClassRoomDTO ConvertToServiceDTO()
    {
        return new global::Api.Service.DTO_s.CreateClassRoomDTO(Code, Capacity);
    }
}