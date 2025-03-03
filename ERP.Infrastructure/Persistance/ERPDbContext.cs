using ERP.Domain;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistance;

public class ERPDbContext: DbContext
{
    public ERPDbContext(DbContextOptions<ERPDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Attendance> Attendances { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Parent> Parents { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<FeePayement> FeePayements { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Exam> Exams { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<Video> Videos { get; set; }
}