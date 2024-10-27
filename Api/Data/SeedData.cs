using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bogus;
using Api.Models;

namespace Api.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()
            ))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var environment = serviceProvider.GetRequiredService<IHostEnvironment>();

                var roles = new[] { "ADMIN", "STUDENT" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                if (userManager.Users.All(u => u.UserName != "admin@mail.com"))
                {
                    var adminUser = new ApplicationUser { UserName = "admin", Email = "admin@mail.com" };
                    await userManager.CreateAsync(adminUser, "AdminPassword123!");
                    await userManager.AddToRoleAsync(adminUser, "ADMIN");
                }

                if (environment.IsDevelopment() && !context.Courses.Any())
                {
                    var courses = new[] {
                       new Course()
                       {
                            Description = "Computer Science",
                            Subjects = new List<Subject>
                            {
                                new Subject() { Description = "Discrete Mathematics", Session = Session.Fall },
                                new Subject() { Description = "Linear Algebra", Session = Session.Fall },
                                new Subject() { Description = "Calculus", Session = Session.Fall },
                                new Subject() { Description = "Introduction to Programming", Session = Session.Spring },
                                new Subject() { Description = "Data Structures", Session = Session.Spring },
                                new Subject() { Description = "Algorithms", Session = Session.Spring },
                                new Subject() { Description = "Software Development", Session = Session.Winter },
                                new Subject() { Description = "Operating Systems", Session = Session.Winter },
                                new Subject() { Description = "Computer Architecture", Session = Session.Winter },
                                new Subject() { Description = "Computer Networks", Session = Session.Summer },
                                new Subject() { Description = "Theory of Computation", Session = Session.Summer },
                                new Subject() { Description = "Database Systems", Session = Session.Summer },
                                new Subject() { Description = "Artificial Intelligence", Session = Session.Fall },
                                new Subject() { Description = "Machine Learning", Session = Session.Fall },
                                new Subject() { Description = "Information Security", Session = Session.Fall },
                                new Subject() { Description = "Web Development", Session = Session.Spring },
                                new Subject() { Description = "Mobile Application Development", Session = Session.Spring },
                                new Subject() { Description = "Human-Computer Interaction", Session = Session.Winter },
                                new Subject() { Description = "Computer Graphics", Session = Session.Winter },
                                new Subject() { Description = "Cloud Computing", Session = Session.Spring },
                                new Subject() { Description = "Software Project", Session = Session.Fall },
                                new Subject() { Description = "Internship", Session = Session.Spring }
                            }
                        },
                        new Course()
                        {
                            Description = "Hotel Management",
                            Subjects = new List<Subject>
                            {
                                new Subject() { Description = "Introduction to Hospitality", Session = Session.Fall },
                                new Subject() { Description = "Hotel Operations", Session = Session.Fall },
                                new Subject() { Description = "Food and Beverage Management", Session = Session.Spring },
                                new Subject() { Description = "Front Office Management", Session = Session.Spring },
                                new Subject() { Description = "Event Management", Session = Session.Spring },
                                new Subject() { Description = "Housekeeping Management", Session = Session.Winter },
                                new Subject() { Description = "Revenue Management", Session = Session.Winter },
                                new Subject() { Description = "Marketing for Hospitality", Session = Session.Summer },
                                new Subject() { Description = "Sustainable Practices in Hospitality", Session = Session.Summer }
                            }
                        },
                        new Course()
                        {
                            Description = "Digital Marketing",
                            Subjects = new List<Subject>
                            {
                                new Subject() { Description = "Introduction to Digital Marketing", Session = Session.Fall },
                                new Subject() { Description = "Social Media Marketing", Session = Session.Fall },
                                new Subject() { Description = "Search Engine Optimization", Session = Session.Spring },
                                new Subject() { Description = "Content Marketing", Session = Session.Spring },
                                new Subject() { Description = "Email Marketing", Session = Session.Winter },
                                new Subject() { Description = "Digital Advertising", Session = Session.Winter },
                                new Subject() { Description = "Analytics for Digital Marketing", Session = Session.Summer },
                                new Subject() { Description = "Mobile Marketing", Session = Session.Summer },
                                new Subject() { Description = "Influencer Marketing", Session = Session.Spring }
                            }
                        },
                        new Course()
                        {
                            Description = "Game Development",
                            Subjects = new List<Subject>
                            {
                                new Subject() { Description = "Introduction to Game Design", Session = Session.Fall },
                                new Subject() { Description = "Game Programming", Session = Session.Fall },
                                new Subject() { Description = "Game Physics", Session = Session.Spring },
                                new Subject() { Description = "3D Modeling and Animation", Session = Session.Spring },
                                new Subject() { Description = "Level Design", Session = Session.Winter },
                                new Subject() { Description = "Artificial Intelligence in Games", Session = Session.Winter },
                                new Subject() { Description = "Game Production", Session = Session.Summer },
                                new Subject() { Description = "Multiplayer Game Development", Session = Session.Summer },
                                new Subject() { Description = "Virtual Reality Development", Session = Session.Spring }
                            }
                        }
                    };

                    await context.Courses.AddRangeAsync(courses);
                    await context.SaveChangesAsync();

                }

                if (environment.IsDevelopment() && !context.Students.Any())
                {

                    Course[] courses = await context.Courses.ToArrayAsync();

                    var students = new List<Student>();

                    for (int i = 0; i < 123; i++)
                    {

                        var student = new Faker<Student>()
                            .RuleFor(p => p.Name, f => f.Name.FullName())
                            .RuleFor(p => p.Dob, f => DateOnly.FromDateTime(f.Date.Past(f.Random.Int(19, 40))))
                            .Generate();

                        students.Add(student);
                    }

                    await context.Students.AddRangeAsync(students);
                    await context.SaveChangesAsync();

                }

                if (environment.IsDevelopment() && !context.StudentCourse.Any())
                {
                    Student[] students = await context.Students.ToArrayAsync();
                    Course[] courses = await context.Courses.ToArrayAsync();

                    List<StudentCourse> studentCourses = new List<StudentCourse>();
                    foreach (var student in students)
                    {

                        Random random = new Random();
                        int randomIndex = random.Next(courses.Length);
                        Course randomCourse = courses[randomIndex];

                        StudentCourse studentCourse = new StudentCourse()
                        {
                            Student = student,
                            Course = randomCourse
                        };

                        studentCourses.Add(studentCourse);
                    }

                    await context.StudentCourse.AddRangeAsync(studentCourses);
                    await context.SaveChangesAsync();

                }

                if (environment.IsDevelopment() && !context.StudentCourseGrade.Any())
                {
                    Console.WriteLine("AQUI");
                    StudentCourse[] studentCourses = await context.StudentCourse.ToArrayAsync();

                    foreach (var studentCourse in studentCourses)
                    {
                        List<Subject> subjects = await context.Subjects.Where(s => s.CourseId == studentCourse.CourseId).ToListAsync();

                        List<StudentCourseGrade> studentCourseGrades = new List<StudentCourseGrade>();
                        foreach (var subject in subjects)
                        {
                            var studentCourseGrade = new Faker<StudentCourseGrade>()
                                .RuleFor(p => p.StudentCourseId, f => studentCourse.Id)
                                .RuleFor(p => p.SubjectId, f => subject.Id)
                                .RuleFor(p => p.Extra, f => Math.Round(f.Random.Double(0, 100), 2))
                                .RuleFor(p => p.MidTerm, f => Math.Round(f.Random.Double(0, 100), 2))
                                .RuleFor(p => p.FinalExam, f => Math.Round(f.Random.Double(0, 100), 2))
                                .Generate();
                            studentCourseGrades.Add(studentCourseGrade);
                        }
                        await context.StudentCourseGrade.AddRangeAsync(studentCourseGrades);
                    }
                    await context.SaveChangesAsync();
                }


            }
        }
    }
}
