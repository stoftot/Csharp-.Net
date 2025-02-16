using System.Text;

namespace Api.Service.DTO_s;

public class GetCourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public GetTeacherDTO? CourseAdministrator { get; set; }
    public GetTeacherDTO? Teacher { get; set; }
    public GetClassRoomDTO? ClassRoom { get; set; }
}

public class CreateCourseDTO(string name, int capacity)
{
    public required string Code { get; set; } = GenerateCourseCode(name);
    public required string Name { get; set; } = name;
    public required int Capacity { get; set; } = capacity;

    private static string GenerateCourseCode(string name)
    {
        var code = new StringBuilder();
        var parts = name.Split(" ");
        foreach (var part in parts)
        {
            code.Append(part[..1].ToUpper());
        }
        return code.ToString();
    }
}
