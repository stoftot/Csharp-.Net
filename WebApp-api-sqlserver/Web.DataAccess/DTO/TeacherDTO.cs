﻿namespace Web.DataAccess.DTO;

public class TeacherDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<SubjectDTO>? Subjects { get; set; }
    public IEnumerable<CourseDTO>? Courses { get; set; }
}