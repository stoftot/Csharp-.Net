namespace Web.Api.DTO_s;

public class GetSubjectDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }

    public static GetSubjectDto? ConvertServiceDto(global::Api.Service.DTO_s.GetSubjectDto? dto)
    {
        if (dto == null) return null;
        return new GetSubjectDto
        {
            Code = dto.Code,
            Name = dto.Name
        };
    }
}

public class CreateSubjectDto
{
    public required string Name { get; set; }

    public global::Api.Service.DTO_s.CreateSubjectDto ConvertToServiceDto()
    {
        return new global::Api.Service.DTO_s.CreateSubjectDto(Name);
    }
}