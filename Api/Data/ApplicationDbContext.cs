using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<StudentCourseGrade> StudentCourseGrade { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentCourseGrade>()
                .Property(p => p.Extra)
                .HasColumnType("decimal(18,2)");

            builder.Entity<StudentCourseGrade>()
                .Property(p => p.MidTerm)
                .HasColumnType("decimal(18,2)");

            builder.Entity<StudentCourseGrade>()
                .Property(p => p.FinalExam)
                .HasColumnType("decimal(18,2)");

            builder.Entity<StudentCourse>()
                .HasIndex(sc => new { sc.StudentId, sc.CourseId })
                .IsUnique();

            builder.Entity<StudentCourseGrade>()
                .HasIndex(sc => new { sc.StudentCourseId, sc.SubjectId })
                .IsUnique();

            builder.Entity<Subject>()
                .Property(s => s.Session)
                .HasConversion<string>();

            builder.Entity<StudentCourseGrade>()
                .HasOne(scg => scg.StudentCourse)
                .WithMany(sc => sc.StudentCourseGrade)
                .HasForeignKey(scg => scg.StudentCourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentCourseGrade>()
                .HasOne(scg => scg.Subject)
                .WithMany()
                .HasForeignKey(scg => scg.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
