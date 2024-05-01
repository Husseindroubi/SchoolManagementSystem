using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public DateTime DatePosted { get; set; }
        
    }
}
