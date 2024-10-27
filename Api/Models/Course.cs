using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
