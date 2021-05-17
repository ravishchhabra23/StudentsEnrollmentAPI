using Microsoft.EntityFrameworkCore;
using StudentsEnrollment.Persist.Domain;

namespace StudentsEnrollment.Persist.Data
{
    public class StudentEnrollmentContext : DbContext
    {
        public StudentEnrollmentContext(DbContextOptions<StudentEnrollmentContext> options) : base(options)
        {
        }

        public DbSet<Subject> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MN8EGV0E\MYLOCALINSTANCE;Initial Catalog=StudentEnrollment;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }    
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Lecture>().ToTable("Lecture");
            modelBuilder.Entity<LectureTheatre>().ToTable("LectureTheatre");
        }
    }
}
