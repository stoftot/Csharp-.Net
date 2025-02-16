namespace Web.Api.DTO_s;

public class GetSubjectDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}

public class CreateSubjectDTO(string name)
{
    public required string Name { get; init; } = name;
}