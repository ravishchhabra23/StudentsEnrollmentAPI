using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsEnrollment.Application.Commands.AddStudent;
using StudentsEnrollment.Application.Models;
using StudentsEnrollment.Application.Queries.GetStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentsEnrollmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IMediator mediator, ILogger<StudentController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _mediator.Send(new GetStudentsQuery(), cancellationToken: CancellationToken.None);
            return new OkObjectResult(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentModel studentModel)
        {
            var addCommand = new AddStudentCommand();
            addCommand.StudentModel = studentModel;
            var added = await _mediator.Send(addCommand, cancellationToken: CancellationToken.None);
            return new OkObjectResult(added);
        }
    }
}
