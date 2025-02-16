using System.Text;

namespace Api.Service.DTO_s;

public class GetCourseDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public GetTeacherDto? CourseAdministrator { get; set; }
    public GetTeacherDto? Teacher { get; set; }
    public GetClassroomDto? ClassRoom { get; set; }
}

public class CreateCourseDto(string name, int capacity)
{
    public string Code { get; } = GenerateCourseCode(name);
    public string Name { get; } = name;
    public int Capacity { get; } = capacity;

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
