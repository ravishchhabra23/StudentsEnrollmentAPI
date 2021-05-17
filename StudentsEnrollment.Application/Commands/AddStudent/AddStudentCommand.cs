using MediatR;
using StudentsEnrollment.Persist.Data;
using System.Threading;
using System.Threading.Tasks;
using StudentsEnrollment.Application.Extensions;
using StudentsEnrollment.Application.Models;

namespace StudentsEnrollment.Application.Commands.AddStudent
{
    public class AddStudentCommand : IRequest<int>
    {
        public StudentModel StudentModel { get; set; }
        public class AddOccupationCommandHandler : IRequestHandler<AddStudentCommand, int>
        {
            private readonly StudentEnrollmentContext _studentEnrollmentContext;
            public AddOccupationCommandHandler(StudentEnrollmentContext studentEnrollmentContext)
            {
                _studentEnrollmentContext = studentEnrollmentContext;
            }

            public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
            {
                var add = await _studentEnrollmentContext.AddAsync(request.StudentModel.ToDbModel());
                var save = await _studentEnrollmentContext.SaveChangesAsync();
                return save;
            }
        }
    }
}
