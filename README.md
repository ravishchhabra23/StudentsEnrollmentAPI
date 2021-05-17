# StudentsEnrollment

### Compile and Run the solution
Open the solution in VS 2019. Compile the solution  and set the project "StudentsEnrollmentAPI" as the "startup project" and run. This will display the local URLs that can be used to run the functions locally.

### Note
Before running the project,kindly change the connectionstring to have a valid Server name. Solution will automatically create the database with the code first approach with the domain model created.

### Add/Get Students 
This excercise returns students and add a student in the database.

Rest of the operations were not developed but will be mostly similar to the operations developed.

### Response for AddStudent
![image](https://user-images.githubusercontent.com/28916581/118520381-60eef480-b77d-11eb-9933-f06e7d294309.png)

### Response for GetStudents
![image](https://user-images.githubusercontent.com/28916581/118520770-b0352500-b77d-11eb-899c-8b01c886686b.png)

## Technical Details
- Solution is developed using .NET Core 3.1 and Asp.Net Web Api. EntityFrameworkCore is used with code first approach following the DDD approach.
- CQRS pattern is implemented with mediator to bring in the abstraction layer for the interactions with the database. This will particularly be beneficial in   microservices architectures where we can have read and write databases seperately for performance.
- FluentValidations are used for setting the validation business rules.
- Unit test: MSTest and Moq is used as mocking framework.
- In-Memory database is used to mock the EFCore operations.
- LoggingBehavior is handled in APplication layer using middleware and MS in built logging is used in API
- Extensions are used for Mapping objects.
- Autofac container is used to inject mediator dependencies

Improvements that can be done :-
- Cross cutting concerns like Authentication, Authorization can be implemented for security.
- Cors can be added to further specify the resources need to be allowed by browser.
- Secure headers can be added for further security.
- Caching can be implemented to improve performance.

  
