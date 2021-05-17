namespace StudentsEnrollment.Persist.Data
{
    public interface IDesignTimeContextFactory
    {
        StudentEnrollmentContext CreateDbContext(string[] args);
    }
}
