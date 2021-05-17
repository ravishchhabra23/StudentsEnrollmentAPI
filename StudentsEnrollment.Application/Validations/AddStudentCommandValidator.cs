using FluentValidation;
using StudentsEnrollment.Application.Commands.AddStudent;

namespace StudentsEnrollment.Application.Validations
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(p => p.StudentModel)
                .NotEmpty();
            RuleFor(p => p.StudentModel.FirstName)
                .NotEmpty();
            RuleFor(p => p.StudentModel.LastName)
                .NotEmpty();
        }
    }
}
