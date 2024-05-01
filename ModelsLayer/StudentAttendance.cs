using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsLayer
{
    public class StudentAttendance
    {
        [Key]
        public int StudentAttendanceId { get; set; }
        public string? ClassName { get; set; }
        public string? StudentName { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        
    }
}
