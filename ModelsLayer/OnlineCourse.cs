using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class OnlineCourse
    {
        [Key]
        public int OnlineCourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? InstructorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EnrollmentLimit { get; set; }
    }
}
