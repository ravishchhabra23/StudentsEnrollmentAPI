using Microsoft.EntityFrameworkCore;

namespace StudentsEnrollment.Persist.Data
{
    public class DesignTimeContextFactory: IDesignTimeContextFactory
    {
        public StudentEnrollmentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentContext>();
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MN8EGV0E\MYLOCALINSTANCE;Initial Catalog=StudentEnrollment;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new StudentEnrollmentContext(optionsBuilder.Options);
        }
    }
}
