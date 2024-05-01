   using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }   
}
