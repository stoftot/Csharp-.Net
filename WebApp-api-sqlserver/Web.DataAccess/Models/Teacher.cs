namespace Web.Api.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Subject>? Subjects { get; set; }
    public List<Course>? Courses { get; set; }
}