using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Dob { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }

    }
}
