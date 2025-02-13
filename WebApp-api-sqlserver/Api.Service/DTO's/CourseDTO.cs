using System.Text;

namespace Api.Service.DTO_s;

public class CourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public TeacherDTO? CourseAdministrator { get; set; }
    public TeacherDTO? Teacher { get; set; }
    public ClassRoomDTO? ClassRoom { get; set; }

    public CourseDTO(string name, int capacity)
    {
        Code = GenerateCourseCode(name);
        Name = name;
        Capacity = capacity;
    }
    
    public static string GenerateCourseCode(string name)
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