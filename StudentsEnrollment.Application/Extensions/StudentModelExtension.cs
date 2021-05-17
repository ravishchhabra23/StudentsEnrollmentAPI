using StudentsEnrollment.Application.Models;
using StudentsEnrollment.Persist.Domain;

namespace StudentsEnrollment.Application.Extensions
{
    public static class DBModelExtensions
    {
        public static Student ToDbModel(this StudentModel studentModel)
        {
            return new Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName
            };
        }
    }

    public static class ModelExtensions
    {
        public static StudentModel ToStudentModel(this Student student)
        {
            return new StudentModel
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
    }
}
