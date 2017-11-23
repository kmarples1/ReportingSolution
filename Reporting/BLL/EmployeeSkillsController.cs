using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.DAL;

namespace WorkSchedule.System.BLL
{

    [DataObject]
    public class EmployeeSkillController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillStatus> GetEmployeeSkills()
        {
            using (var context = new WorkScheduleContext())
            {
                var result = from data in context.EmployeeSkills
                             select new SkillStatus
                             {
                                 Skill = data.Skill.Description,
                                 Name = data.Employee.FirstName + " " + data.Employee.LastName,
                                 Level = data.Level == 1? "Novice": data.Level ==2? "Proficient": "Expert",
                                 YOE = data.YearsOfExperience

                             };

                return result.ToList();
            }
        }
    }

    //public List<SkillStatus> GetEmployeeSkills()
    //{
    //    using (var context = new WorkScheduleContext())
    //    {
    //        var result = from emp in context.Employees
    //                     from data in emp.EmployeeSkills
    //                     orderby data.Skill.Description, emp.Name
    //                     select new SkillStatus
    //                     {
    //                         Skill = data.Skill.Description,
    //                         Name = emp.Name,
    //                         Phone = emp.HomePhone,
    //                         Level = data.Level.ToString(),
    //                         YOE = data.YearsOfExperience 
    //                     };
    //        return result.ToList();
    //    }
    //}

}

