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
    //[DataObject]
    //public class EmployeeSkillsController
    //{
    //    [DataObjectMethod(DataObjectMethodType.Select)]
    //    public List<SkillStatus> GetSkillStatus()
    //    {
    //        using (var context = new WorkScheduleContext())
    //        {
    //            var results = from data in context.Skills
    //                          from ski in data.EmployeeSkills
    //                          orderby ski.Skill
    //                          select new SkillStatus
    //                          {
    //                              Skill = data.Description,
    //                              // Name = data.Employee.FirstName,
    //                              // Phone = data.Phone,
    //                              // YOE = data.YOE
    //                          };
    //            return results.ToList();
    //        }
    //    }

    [DataObject]
    public class EmployeeSkillController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillStatus> GetEmployeeSkills()
        {
            using (var context = new WorkScheduleContext())
            {
                var result = from emp in context.Employees
                             from data in emp.EmployeeSkills
                             orderby data.Skill.Description, emp.LastName
                             select new SkillStatus
                             {
                                 Skill = data.Skill.Description,
                                 Name = emp.LastName,
                                 Phone = emp.HomePhone,
                                 //Level = data.Level,
                                 //YOE = data.YearsOfExperience 
                             };
                return result.ToList();
            }
        }
    }

}

