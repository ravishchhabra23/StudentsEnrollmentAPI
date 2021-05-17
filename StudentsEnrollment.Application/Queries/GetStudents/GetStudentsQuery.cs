using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentsEnrollment.Application.Models;
using StudentsEnrollment.Persist.Data;
using System.Collections.Generic;
using System.Threading;
using StudentsEnrollment.Application.Extensions;
using System.Threading.Tasks;

namespace StudentsEnrollment.Application.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<List<StudentModel>>
    {
        public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentModel>>
        {
            private readonly StudentEnrollmentContext _studentEnrollmentContext;
            public GetStudentsQueryHandler(StudentEnrollmentContext studentEnrollmentContext)
            {
                _studentEnrollmentContext = studentEnrollmentContext;
            }
            public async Task<List<StudentModel>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
            {
                List<StudentModel> studentModels = new List<StudentModel>();
                var students = await _studentEnrollmentContext.Students.ToListAsync();
                foreach(var student in students)
                {
                    studentModels.Add(student.ToStudentModel());
                }
                return studentModels;
            }
        }
    }
}
