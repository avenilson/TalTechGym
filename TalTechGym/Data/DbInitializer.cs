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

            var instructors = new Instructor[] 
            {
                new Instructor { FirstMidName = "Madis",     LastName = "Koit",
                    HireDate = DateTime.Parse("2015-03-11") },
                new Instructor { FirstMidName = "Uku",    LastName = "Rummi",
                    HireDate = DateTime.Parse("2012-07-06") },
                new Instructor { FirstMidName = "Kris",   LastName = "Killing",
                    HireDate = DateTime.Parse("2013-07-01") },
                new Instructor { FirstMidName = "Brenda", LastName = "Valtson",
                    HireDate = DateTime.Parse("2011-01-15") },
                new Instructor { FirstMidName = "Kristi",   LastName = "Aedma",
                    HireDate = DateTime.Parse("2014-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[] 
            {
                new Department { Name = "Group exercise",     Budget = 35000,
                    StartDate = DateTime.Parse("2019-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Aedma").ID },
                new Department { Name = "Volleyball", Budget = 10000,
                    StartDate = DateTime.Parse("2019-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Rummi").ID },
                new Department { Name = "Basketball", Budget = 35000,
                    StartDate = DateTime.Parse("2019-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Killing").ID },
                new Department { Name = "Badminton and table tennis",   Budget = 10000,
                    StartDate = DateTime.Parse("2019-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Koit").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Mobility",Credits=3,DepartmentID = departments.Single( s => s.Name == "Group exercise").DepartmentID},
            new Course{CourseID=1060,Title="Endurance",Credits=3,DepartmentID = departments.Single( s => s.Name == "Group exercise").DepartmentID},
            new Course{CourseID=3060,Title="Basketball",Credits=3,DepartmentID = departments.Single( s => s.Name == "Basketball").DepartmentID},
            new Course{CourseID=3050,Title="Volleyball",Credits=4,DepartmentID = departments.Single( s => s.Name == "Volleyball").DepartmentID},
            new Course{CourseID=2030,Title="Badminton",Credits=4,DepartmentID = departments.Single( s => s.Name == "Badminton and table tennis").DepartmentID},
            new Course{CourseID=2020,Title="Table Tennis",Credits=3,DepartmentID = departments.Single( s => s.Name == "Badminton and table tennis").DepartmentID},
            new Course{CourseID=1070,Title="Yoga",Credits=4,DepartmentID = departments.Single( s => s.Name == "Group exercise").DepartmentID}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Killing").ID,
                    Location = "U02-202" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Koit").ID,
                    Location = "U03-303" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Aedma").ID,
                    Location = "U04-404" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Mobility" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Aedma").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Endurance" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Aedma").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Yoga" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Valtson").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Basketball" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Killing").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Volleyball" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Rummi").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Badminton" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Koit").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Table tennis" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Koit").ID
                    }
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nilson").ID,
                    CourseID = courses.Single(c => c.Title == "Badminton" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nilson").ID,
                    CourseID = courses.Single(c => c.Title == "Endurance" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Nilson").ID,
                    CourseID = courses.Single(c => c.Title == "Table tennis" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Volleyball" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kaevats").ID,
                    CourseID = courses.Single(c => c.Title == "Mobility" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kalam").ID,
                    CourseID = courses.Single(c => c.Title == "Yoga" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kalam").ID,
                    CourseID = courses.Single(c => c.Title == "Endurance" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kluge").ID,
                    CourseID = courses.Single(c => c.Title == "Basketball").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kluge").ID,
                    CourseID = courses.Single(c => c.Title == "Endurance").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Talving").ID,
                    CourseID = courses.Single(c => c.Title == "Volleyball").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Polder").ID,
                    CourseID = courses.Single(c => c.Title == "Yoga").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
