using Microsoft.EntityFrameworkCore;
using Web.Api.Models;

namespace Web.Api.Data;

public class UniversityDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    public UniversityDbContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {
        
    }
}