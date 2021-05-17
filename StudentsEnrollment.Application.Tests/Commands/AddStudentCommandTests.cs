using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudentsEnrollment.Application.Commands.AddStudent;
using StudentsEnrollment.Application.Models;
using StudentsEnrollment.Persist.Data;
using StudentsEnrollment.Persist.Domain;
using System;
using System.Threading.Tasks;
using static StudentsEnrollment.Application.Commands.AddStudent.AddStudentCommand;

namespace InsurancePremiumCalc.Application.Tests
{
    [TestFixture]
    public class AddStudentCommandTests
    {
        private StudentEnrollmentContext context = null;
        [SetUp]
        public void SetUp()
        {

            var builder = new DbContextOptionsBuilder<StudentEnrollmentContext>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            var options = builder.Options;
            context = new StudentEnrollmentContext(options);
        }

        [Test]
        public async Task AddOccupation_Success()
        {
            var studentModel = new StudentModel
            {
                FirstName ="Tom",
                LastName = "Hanks"
            };
            MockRepository repository = new MockRepository(MockBehavior.Default);
            var mediator = repository.Create<IMediator>();
            mediator.Setup(x => x.Send(studentModel, System.Threading.CancellationToken.None))
                .Returns(new System.Threading.Tasks.Task<object>(() => ReturnBoolean(true)));
            var student= new Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName
            };

            var builder = new DbContextOptionsBuilder<StudentEnrollmentContext>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            var options = builder.Options;
            var addStudent = new AddStudentCommand();
            addStudent.StudentModel = studentModel;
            var addOccupationHandler = new AddOccupationCommandHandler(context);
            var result = await addOccupationHandler.Handle(addStudent, System.Threading.CancellationToken.None);

            Assert.AreEqual(Convert.ToInt32(result), 1);
            var resultStudent = context.Students.FirstOrDefaultAsync(p=>p.FirstName == studentModel.FirstName);
            Assert.AreEqual(resultStudent.Result.FirstName, studentModel.FirstName);
            mediator.Verify();
        }
        [TearDown]
        public void TearDown()
        {
            context.DisposeAsync();
        }
        private bool ReturnBoolean(bool value)
        {
            return value;
        }
    }
}
