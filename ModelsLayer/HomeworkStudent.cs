using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsLayer
{
    public class HomeworkStudent
    {
        [Key]
        public int HomeworkStudentId { get; set; }
        public int HomeworkId { get; set; }
        [ForeignKey("HomeworkId")]
        public Homework? Homework { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedTeacher { get; set; }
        public string? Notes { get; set; }
    }
}
