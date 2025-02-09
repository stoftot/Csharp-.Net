using System.Text;
using Web.DataAccess.Models;

namespace Web.DataAccess.DTO;

public class CourseDTO
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }

    public TeacherDTO? CourseAdministrator { get; set; }
    public TeacherDTO? Teacher { get; set; }
    public ClassRoomDTO? ClassRoom { get; set; }

    public CourseDTO()
    {
    }

    public CourseDTO(string name, int capacity)
    {
        Code = Course.GenerateCourseCode(name);
        Name = name;
        Capacity = capacity;
    }
}