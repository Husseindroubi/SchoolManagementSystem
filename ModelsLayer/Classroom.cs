
using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class Classroom
    {
        [Key] public int ClassroomId { get; set; }
        public string? ClassroomName { get; set; }
        public string? Description { get; set; }

        public List<WeeklyPlan>? WeeklyPlans { get; set; } 

    }

}
