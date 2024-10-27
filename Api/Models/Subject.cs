using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{

    public enum Session
    {
        Summer = 0,
        Fall = 1,
        Winter = 2,
        Spring = 3,
    }

    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public Session Session { get; set; }

        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}
