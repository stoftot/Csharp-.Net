namespace Web.Api.DTO_s;

public class GetSubjectDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }

    public static GetSubjectDTO? ConvertServiceDTO(global::Api.Service.DTO_s.GetSubjectDTO? dto)
    {
        if (dto == null) return null;
        return new GetSubjectDTO
        {
            Code = dto.Code,
            Name = dto.Name
        };
    }
}

public class CreateSubjectDTO(string name)
{
    public required string Name { get; init; } = name;
}