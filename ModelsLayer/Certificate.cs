
using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class Certificate
    {
        [Key] public int CertificateId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string? RecipientName { get; set; }
        public string? IssuerName { get; set; }
    }
}
