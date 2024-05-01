using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsLayer
{
    public class ExamStudent
    {
        [Key] public int ExamStudentId { get; set; }
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }
        public double Score { get; set; } 
    }
}
