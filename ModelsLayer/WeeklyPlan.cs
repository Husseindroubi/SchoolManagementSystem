using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class WeeklyPlan
    {
        [Key]
        public int WeeklyPlanId { get; set; }
        /*public int ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]*/
        public Classroom? Classroom { get; set; }

        /*public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }*/

        public DateTime WeekStartDate { get; set; }
        public List<DailyPlan>? DailyPlans { get; set; }
    }
}
