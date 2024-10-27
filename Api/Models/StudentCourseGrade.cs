using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public struct Weight
    {
        public const double Extra = 0.3;
        public const double MidTerm = 0.3;
        public const double FinalExam = 0.4;
    }

    public class StudentCourseGrade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentCourseId { get; set; }

        [JsonIgnore]
        public StudentCourse StudentCourse { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [JsonIgnore]
        public Subject Subject { get; set; }

        [Range(0, 100, ErrorMessage = "Extra cannot exceed 100.")]
        public double? Extra { get; set; }

        [Range(0, 100, ErrorMessage = "MidTerm cannot exceed 100.")]
        public double? MidTerm { get; set; }

        [Range(0, 100, ErrorMessage = "FinalExam cannot exceed 100.")]
        public double? FinalExam { get; set; }

        [NotMapped]
        public double FinalGrade
        {
            get
            {
                // Calcular a nota final utilizando os pesos definidos
                double extraWeighted = (Extra ?? 0) * Weight.Extra;
                double midTermWeighted = (MidTerm ?? 0) * Weight.MidTerm;
                double finalExamWeighted = (FinalExam ?? 0) * Weight.FinalExam;

                double totalWeighted = extraWeighted + midTermWeighted + finalExamWeighted;
                return Math.Round(totalWeighted, 2, MidpointRounding.AwayFromZero);
            }
        }

        public bool IsFinal
        {
            get
            {
                return Extra.HasValue && MidTerm.HasValue && FinalExam.HasValue;
            }
        }
    }
}
