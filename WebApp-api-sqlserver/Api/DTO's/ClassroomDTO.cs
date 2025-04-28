namespace Web.Api.DTO_s;

public class GetClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }

    public static GetClassroomDto? ConvertServiceDto(global::Api.Service.DTO_s.GetClassroomDto? dto)
    {
        if (dto == null) return null;
        return new GetClassroomDto
        {
            Code = dto.Code,
            Capacity = dto.Capacity
        };
    }
}

public class CreateClassroomDto
{
    public required string Code { get; set; }
    public required int Capacity { get; set; }

    public global::Api.Service.DTO_s.CreateClassroomDto ConvertToServiceDto()
    {
        return new global::Api.Service.DTO_s.CreateClassroomDto(Code, Capacity);
    }
}

public class UpdateClassroomDto
{
    public required int Capacity { get; set; }

    public global::Api.Service.DTO_s.UpdateClassRoomDto ConvertToServiceDto(string code)
    {
        return new global::Api.Service.DTO_s.UpdateClassRoomDto(code, Capacity);
    }
}