using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsLayer
{
    public class Homework
    {
        [Key] public int HomeworkId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public string? Subject { get; set; }
        public string? ClassName { get; set; }
        public string? Content { get; set; }
    }
}

