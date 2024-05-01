using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DailyPlan
    {
        [Key]
        public int DailyPlanId { get; set; }
        public int WeeklyPlanId { get; set; }
        [ForeignKey("WeeklyPlanId")]
        public WeeklyPlan? WeeklyPlan { get; set; }

        public List<Topic>? Topics { get; set; }
    }
}
