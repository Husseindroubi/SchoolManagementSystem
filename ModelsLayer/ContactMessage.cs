

using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class ContactMessage
    {
        [Key]
        public int MessageId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
