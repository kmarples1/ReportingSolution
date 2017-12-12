using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Data.Entities.POCOs
{
    public class SkillSet : EmployeeSkill
    {
        public string Skill { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int SkillID { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public int? YOE { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyWage { get; set; }
    }
}
