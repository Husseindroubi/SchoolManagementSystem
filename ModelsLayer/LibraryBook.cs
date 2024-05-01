using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class LibraryBook
    {
        [Key]
        public int LibraryBookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImagePath { get; set; }
    }
}
