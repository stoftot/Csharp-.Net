namespace Web.Service.DTO_s;

public class ViewSubjectDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}

public class CreateSubjectDto
{
    public required string Name { get; set; }
}