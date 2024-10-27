using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{


    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }

        public ICollection<StudentCourseGrade> StudentCourseGrade { get; set; }

    }
}
