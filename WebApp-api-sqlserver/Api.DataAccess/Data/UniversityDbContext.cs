using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Models;

namespace Web.DataAccess.Data;

public class UniversityDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            entity.Property(t => t.Name)
                .IsRequired();

            entity.HasMany(t => t.Subjects)
                .WithMany();
        });
        
        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(s => s.Code);

            entity.Property(s => s.Name)
                .IsRequired();
        });
        
        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasKey(c => c.Code);

            entity.Property(c => c.Capacity)
                .IsRequired();
        });
        
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.Code);

            entity.Property(c => c.Name)
                .IsRequired();
            entity.Property(c => c.Capacity)
                .IsRequired();

            entity.HasOne(c => c.CourseAdministrator)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.CourseAdministratorId)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(c => c.Teacher)
                .WithMany()
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(c => c.ClassRoom)
                .WithMany()
                .HasForeignKey(c => c.ClassRoomCode)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}