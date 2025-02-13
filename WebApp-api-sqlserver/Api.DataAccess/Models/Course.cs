using System.Text;

namespace Web.DataAccess.Models;

public class Course
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }

    public int? CourseAdministratorId { get; set; }
    public Teacher? CourseAdministrator { get; set; }

    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    
    public string? ClassRoomCode { get; set; }
    public ClassRoom? ClassRoom { get; set; }
    
    public static string NormalizeCode(string code) => code.ToUpper();
}