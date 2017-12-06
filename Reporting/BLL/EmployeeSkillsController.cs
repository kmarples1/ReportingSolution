using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.DAL;
using WorkSchedule.Data.Entities;

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
                                 Phone = data.Employee.HomePhone,
                                 Level = data.Level == 1? "Novice": data.Level ==2? "Proficient": "Expert",
                                 YOE = data.YearsOfExperience

                             };

                return result.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillList> Skills_List()
        {
            using (var context = new WorkScheduleContext())
            {
                var result = from data in context.EmployeeSkills
                             select new SkillList
                             {
                                 Skill = data.Skill.Description,
                                 Level = data.Level == 1 ? "Novice" : data.Level == 2 ? "Proficient" : "Expert",
                                 YOE = data.YearsOfExperience,
                                 HourlyWage = data.HourlyWage
                             };

                return result.ToList();
            }
        }
    }

    //[DataObjectMethod(DataObjectMethodType.Select)]
    //public void RegisterSkill(SkillList register)
    //{
    //    if (register == null)
    //        throw new ArgumentNullException("register", "Cannot register skill; skill information was not supplied.");
        
   

    //}




}

