using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Adicionar Curso
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        // Listar Cursos (Paginação)
        [HttpGet]
        public async Task<IActionResult> ListCourses(int page = 1, int pageSize = 10)
        {
            var query = _context.Courses.AsQueryable();
            var totalCourses = await query.CountAsync();
            var courses = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
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

        // Editar Curso
        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id)
                return BadRequest("Course ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
                return NotFound();

            existingCourse.Description = course.Description;
            // Atualize outras propriedades se necessário

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Deletar Curso
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var existingCourse = await _context.Courses.Include(c => c.StudentCourses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCourse == null)
                return NotFound();

            // Impedir a exclusão se houver alunos matriculados
            if (existingCourse.StudentCourses.Any())
                return BadRequest("Cannot delete course with enrolled students.");

            _context.Courses.Remove(existingCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Obter Curso por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // Adicionar Disciplina
        [Authorize(Roles = "ADMIN")]
        [HttpPost("subject")]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseExists = await _context.Courses.AnyAsync(c => c.Id == subject.CourseId);
            if (!courseExists)
                return BadRequest("The specified course does not exist.");

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
        }

        // Listar Disciplinas (Paginação)
        [HttpGet("subject")]
        public async Task<IActionResult> ListSubjects(int page = 1, int pageSize = 10)
        {
            var query = _context.Subjects.Include(s => s.Course).AsQueryable();
            var totalSubjects = await query.CountAsync();
            var subjects = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                TotalCount = totalSubjects,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalSubjects / (double)pageSize),
                Data = subjects.Select(s => new 
                {
                    s.Id,
                    s.Description,
                    s.Session,
                    Course = new 
                    {
                        s.Course.Id,
                        s.Course.Description // Atualizado para usar a propriedade Description
                    }
                })
            };

            return Ok(result);
        }

        // Editar Disciplina
        [Authorize(Roles = "ADMIN")]
        [HttpPut("subject/{id}")]
        public async Task<IActionResult> EditSubject(int id, [FromBody] Subject subject)
        {
            if (id != subject.Id)
                return BadRequest("Subject ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSubject = await _context.Subjects.FindAsync(id);
            if (existingSubject == null)
                return NotFound();

            existingSubject.Description = subject.Description;
            existingSubject.Session = subject.Session;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Obter Disciplina por ID
        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _context.Subjects.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (subject == null)
                return NotFound();

            return Ok(subject);
        }
    }
}
