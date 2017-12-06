using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Data.Entities.POCOs
{
    public class SkillList
    {
        public string Skill { get; set; }
        public string Level { get; set; }
        public int? YOE { get; set; }
        public decimal HourlyWage { get; set; }
    }
}
