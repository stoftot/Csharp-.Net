namespace Web.Api.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Subject> Subjects { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}