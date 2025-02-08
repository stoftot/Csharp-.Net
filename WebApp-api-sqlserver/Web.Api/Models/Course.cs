namespace Web.Api.Models;

public class Course
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Cpacity { get; set; }
    public Teacher CourseAminestre { get; set; }
    public Teacher Teacher { get; set; }
    public ClassRoom ClassRoom { get; set; }
    public IEnumerable<Course> Prequistes { get; set; }
}