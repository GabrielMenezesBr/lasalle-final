using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    class StudentDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? Dob { get; set; }
    }

    class CourseDto
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public List<SubjectDto>? Subjects { get; set; }
    }

    class SubjectDto
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public double? Extra { get; set; }
        public double? MidTerm { get; set; }
        public double? FinalExam { get; set; }
    }

    public class StudentCourseDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class StudentCourseGradeUpdateDto
    {
        public int StudentCourseGradeId { get; set; }
        public double? Extra { get; set; }
        public double? MidTerm { get; set; }
        public double? FinalExam { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetStudents(
        int page = 1,
        int pageSize = 10,
        string? studentName = null,
        DateOnly? dobMin = null,
        DateOnly? dobMax = null)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(studentName))
            {
                query = query.Where(s => s.Name.Contains(studentName));
            }

            if (dobMin.HasValue)
            {
                query = query.Where(s => s.Dob >= dobMin.Value);
            }
            if (dobMax.HasValue)
            {
                query = query.Where(s => s.Dob <= dobMax.Value);
            }

            var totalStudents = await query.CountAsync();

            var students = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Dob = s.Dob,
                })
                .ToListAsync();

            var result = new
            {
                TotalCount = totalStudents,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalStudents / (double)pageSize),
                Data = students
            };

            return Ok(result);
        }

        [HttpGet("{id}")] // TO GET
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            Student student = await _context.Students.FindAsync(id) ?? new Student();

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("{studentId}/course")]
        public async Task<IActionResult> GetCoursesFromStudent(
        int studentId,
        int page = 1,
        int pageSize = 10,
        string? courseName = null)
        {
            bool studentExists = await _context.Students.AnyAsync(s => s.Id == studentId);

            if (!studentExists)
                return NotFound(new { message = "Student not found." });

            var query = _context.StudentCourse.AsQueryable();
            query = query.Where(s => s.StudentId == studentId);

            var totalCourses = await query.CountAsync();


            if (!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(s => s.Course.Description.Contains(courseName));
            }

            var courses = await query
                .Where(s => s.StudentId == studentId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => s.Course)
                .ToListAsync();

            var result = new
            {
                TotalCount = totalCourses,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCourses / (double)pageSize),
                Data = courses
            };

            return Ok(result);
        }

        [HttpGet("{studentId}/course/{courseId}")]
        public async Task<IActionResult> GetGradesFromStudentCourse(
        Session? session,
        int studentId,
        int courseId,
        int page = 1,
        int pageSize = 10,
        string? subjectName = null)
        {
            bool studentExists = await _context.Students.AnyAsync(s => s.Id == studentId);

            if (!studentExists)
                return NotFound(new { message = "Student not found." });

            bool sudentCourseExists = await _context.StudentCourse.AnyAsync(s => s.StudentId == studentId && s.CourseId == courseId);

            if (!sudentCourseExists)
                return NotFound(new { message = "Student not have this course." });

            int studentCourseId = await _context.StudentCourse
                .Where(s => s.StudentId == studentId && s.CourseId == courseId)
                .Select(s => s.Id).FirstOrDefaultAsync();

            var query = _context.StudentCourseGrade.AsQueryable();
            query = query.Where(s => s.StudentCourseId == studentCourseId);

            var totalStudentCourseGrade = await query.CountAsync();

            if (session is not null)
            {
                query = query.Where(s => s.Subject.Session.Equals(session));
            }

            if (!string.IsNullOrEmpty(subjectName))
            {
                query = query.Where(s => s.Subject.Description.Contains(subjectName));
            }

            var studentCourseGrades = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new
                {
                    s.Id,
                    Subject = s.Subject.Description,
                    Session = s.Subject.Session.ToString(),
                    s.Extra,
                    s.MidTerm,
                    s.FinalExam,
                    s.FinalGrade,
                    s.IsFinal
                })
                .ToListAsync();

            var result = new
            {
                TotalCount = totalStudentCourseGrade,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalStudentCourseGrade / (double)pageSize),
                Data = studentCourseGrades
            };

            return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPost("assign-course")]
        public async Task<ActionResult<StudentCourse>> AssignStudentToCourse(StudentCourseDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "Invalid data." });
            }

            bool studentCourseExists = await _context.StudentCourse
                    .AnyAsync(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId);

            if (studentCourseExists)
                return Conflict(new { message = "Student already assigned to this course." });

            var studentCourse = new StudentCourse()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            await _context.StudentCourse.AddAsync(studentCourse); // use AddAsync for async operation
            await _context.SaveChangesAsync();

            var subjects = await _context.Subjects
                .Where(s => s.CourseId == studentCourse.CourseId)
                .ToListAsync();

            var studentCourseGrades = subjects.Select(subject => new StudentCourseGrade()
            {
                StudentCourse = studentCourse,
                Subject = subject,
            }).ToList();

            await _context.StudentCourseGrade.AddRangeAsync(studentCourseGrades);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AssignStudentToCourse), new { id = studentCourse.Id }, studentCourse);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{studentId}/course/{courseId}")]
        public async Task<IActionResult> UpdateStudentGrade(
            int studentId,
            int courseId,
            [FromBody] StudentCourseGradeUpdateDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Invalid data." });

            var studentGrade = await _context.StudentCourseGrade
                .Include(s => s.StudentCourse)
                .ThenInclude(sc => sc.Student)
                .Include(s => s.StudentCourse)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.Id == dto.StudentCourseGradeId);

            if (studentGrade == null)
                return NotFound(new { message = "[Data Processing] Student Grade not found." });

            if (studentGrade.StudentCourse == null)
                return NotFound(new { message = "[Data Processing] Student course not found." });

            if (studentGrade.StudentCourse.Student == null)
                return NotFound(new { message = "[Data Processing] Student not found." });

            if (studentGrade.StudentCourse.Course == null)
                return NotFound(new { message = "[Data Processing] Course not found." });

            if (studentGrade.StudentCourse.Student.Id != studentId)
                return NotFound(new { message = "[Data Processing] This grade does not belong to this Student." });

            if (studentGrade.StudentCourse.Course.Id != courseId)
                return NotFound(new { message = "[Data Processing] This grade/subject does not belong to this Course." });

            if (dto.Extra.HasValue)
                studentGrade.Extra = dto.Extra;

            if (dto.MidTerm.HasValue)
                studentGrade.MidTerm = dto.MidTerm;

            if (dto.FinalExam.HasValue)
                studentGrade.FinalExam = dto.FinalExam;

            _context.StudentCourseGrade.Update(studentGrade);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
