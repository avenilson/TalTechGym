using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalTechGym.Models;

//causes a database to be created when needed and loads test data into the new database
namespace TalTechGym.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TalTechGymContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;   
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Ave",LastName="Nilson",EnrollmentDate=DateTime.Parse("2020-09-01")},
            new Student{FirstMidName="Reia",LastName="Soon",EnrollmentDate=DateTime.Parse("2020-09-01")},
            new Student{FirstMidName="Madli",LastName="Kaevats",EnrollmentDate=DateTime.Parse("2020-09-01")},
            new Student{FirstMidName="Helen",LastName="Kalam",EnrollmentDate=DateTime.Parse("2019-09-01")},
            new Student{FirstMidName="Kristjan",LastName="Penn",EnrollmentDate=DateTime.Parse("2019-09-01")},
            new Student{FirstMidName="Maria",LastName="Polder",EnrollmentDate=DateTime.Parse("2019-09-01")},
            new Student{FirstMidName="Hanna",LastName="Talving",EnrollmentDate=DateTime.Parse("2018-09-01")},
            new Student{FirstMidName="Kaspar",LastName="Kluge",EnrollmentDate=DateTime.Parse("2018-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Mobility",Credits=3},
            new Course{CourseID=4022,Title="Endurance",Credits=3},
            new Course{CourseID=4041,Title="Basketball",Credits=3},
            new Course{CourseID=1045,Title="Volleyball",Credits=4},
            new Course{CourseID=3141,Title="Badminton",Credits=4},
            new Course{CourseID=2021,Title="Table Tennis",Credits=3},
            new Course{CourseID=2042,Title="Yoga",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
