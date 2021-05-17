using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using StudentsEnrollment.Persist.Domain;

namespace StudentsEnrollment.Persist.Data
{
    public static class DBInitializer
    {
        public static StudentEnrollmentContext GetContext()
        {
            var connectionString = @"Data Source=LAPTOP-MN8EGV0E\MYLOCALINSTANCE;Initial Catalog=StudentEnrollment;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptionsBuilder<StudentEnrollmentContext> options = new DbContextOptionsBuilder<StudentEnrollmentContext>();
            options.UseSqlServer(connectionString);
            return new StudentEnrollmentContext(options.Options);
        }

        public static void Initialize(StudentEnrollmentContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var subjects = new Subject[]
            {
            new Subject{SubjectName="Chemistry"},
            new Subject{SubjectName="Microeconomics"},
            new Subject{SubjectName="Macroeconomics"},
            new Subject{SubjectName="Calculus"},
            new Subject{SubjectName="Trigonometry"},
            new Subject{SubjectName="Composition"},
            new Subject{SubjectName="Literature"}
            };
            foreach (Subject s in subjects)
            {
                context.Courses.Add(s);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentId=1,SubjectId=1},
            new Enrollment{StudentId=1,SubjectId=2},
            new Enrollment{StudentId=1,SubjectId=1},
            new Enrollment{StudentId=2,SubjectId=3},
            new Enrollment{StudentId=2,SubjectId=4},
            new Enrollment{StudentId=2,SubjectId=5},
            new Enrollment{StudentId=3,SubjectId=4},
            new Enrollment{StudentId=4,SubjectId=5},
            new Enrollment{StudentId=4,SubjectId=6},
            new Enrollment{StudentId=5,SubjectId=7},
            new Enrollment{StudentId=6,SubjectId=4},
            new Enrollment{StudentId=7,SubjectId=2},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

            var lectureTheatres = new LectureTheatre[]
          {
            new LectureTheatre{TheatreName="Einstein Room"},
            new LectureTheatre{TheatreName="Newton Room"},
            new LectureTheatre{TheatreName="Aristotle Hall"},
            new LectureTheatre{TheatreName="Chemistry Hall"},
            new LectureTheatre{TheatreName="Hulk Hall"},
            new LectureTheatre{TheatreName="Biology Lab"},
          };
            foreach (LectureTheatre lt in lectureTheatres)
            {
                context.LectureTheatres.Add(lt);
            }
            context.SaveChanges();

            var lectures = new Lecture[]
          {
            new Lecture{TheatreId=1,SubjectId=1,DayOfWeek = DayOfWeek.Monday.ToString(),StartTime = new TimeSpan(10,15,0),EndTime = new TimeSpan(11,15,0) },
            new Lecture{TheatreId=1,SubjectId=2,DayOfWeek = DayOfWeek.Thursday.ToString(),StartTime = new TimeSpan(09,0,0),EndTime = new TimeSpan(11,0,0) },
            new Lecture{TheatreId=1,SubjectId=1,DayOfWeek = DayOfWeek.Tuesday.ToString(),StartTime = new TimeSpan(12,15,0),EndTime = new TimeSpan(13,15,0) },
            new Lecture{TheatreId=2,SubjectId=3,DayOfWeek = DayOfWeek.Wednesday.ToString(),StartTime = new TimeSpan(10,15,0),EndTime = new TimeSpan(11,15,0) },
            new Lecture{TheatreId=2,SubjectId=4,DayOfWeek = DayOfWeek.Monday.ToString(),StartTime = new TimeSpan(07,20,0),EndTime = new TimeSpan(10,20,0) },
            new Lecture{TheatreId=2,SubjectId=5,DayOfWeek = DayOfWeek.Tuesday.ToString(),StartTime = new TimeSpan(13,25,0),EndTime = new TimeSpan(14,25,0) },
            new Lecture{TheatreId=3,SubjectId=4,DayOfWeek = DayOfWeek.Friday.ToString(),StartTime = new TimeSpan(08,12,13),EndTime = new TimeSpan(10,18,19) },
            new Lecture{TheatreId=4,SubjectId=5,DayOfWeek = DayOfWeek.Tuesday.ToString(),StartTime = new TimeSpan(06,15,0),EndTime = new TimeSpan(08,15,0) },
            new Lecture{TheatreId=4,SubjectId=6,DayOfWeek = DayOfWeek.Wednesday.ToString(),StartTime = new TimeSpan(07,30,0),EndTime = new TimeSpan(09,30,0) },
            new Lecture{TheatreId=5,SubjectId=7,DayOfWeek = DayOfWeek.Monday.ToString(),StartTime = new TimeSpan(11,45,0),EndTime = new TimeSpan(12,45,0) },
            new Lecture{TheatreId=6,SubjectId=4,DayOfWeek = DayOfWeek.Thursday.ToString(),StartTime = new TimeSpan(07,15,0),EndTime = new TimeSpan(11,15,0) },
            new Lecture{TheatreId=5,SubjectId=2,DayOfWeek = DayOfWeek.Saturday.ToString(),StartTime = new TimeSpan(15,10,0),EndTime = new TimeSpan(16,30,0) },
          };
            foreach (Lecture l in lectures)
            {
                context.Lectures.Add(l);
            }
            context.SaveChanges();
        }
    }
}
