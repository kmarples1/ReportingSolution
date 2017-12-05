using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Data.Entities.POCOs
{
    public class SkillStatus
    {
        // Skill / Name / Phone / Level / YOE
        public string Skill { get;  set; }
        public string Name { get;  set; }
        public string Phone { get;  set; }
        public string Level { get;  set; }
        public int? YOE { get;  set; }
        public decimal HourlyWage { get; set; }
    }
}
