using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsLayer
{
    public class Exam
    {
        [Key] public int ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string? ClassName { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
    }
}
