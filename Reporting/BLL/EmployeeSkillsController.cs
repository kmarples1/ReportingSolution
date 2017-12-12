using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.DAL;
using WorkSchedule.Data.Entities;
using System.Data.Entity;

namespace WorkSchedule.System.BLL
{

    [DataObject]
    public class EmployeeSkillController
    {

        //This was for my reporting section

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
                                 Level = data.Level == 1 ? "Novice" : data.Level == 2 ? "Proficient" : "Expert",
                                 YOE = data.YearsOfExperience

                             };

                return result.ToList();
            }
        }

        //This is for my Transactions section

        //Step one: List the skills
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillSet> SkillsList()
        {
            using (var context = new WorkScheduleContext())
            {
                var results = from data in context.EmployeeSkills
                              select new SkillSet
                              {
                                  Skill = data.Skill.Description,                        
                                  //Level = data.Level == 1 ? "Novice" : data.Level == 2 ? "Proficient" : "Expert",
                                  //YOE = data.YearsOfExperience,
                                  //HourlyWage = data.HourlyWage
                              };

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillSet> ListLevel()
        {
            using (var context = new WorkScheduleContext())
            {
                var results = from data in context.EmployeeSkills
                              select new SkillSet
                              {
                                  Level = data.Level == 1 ? "Novice" : data.Level == 2 ? "Proficient" : "Expert"
                              };
                return results.ToList();
            }

        }
     
            
    
        //Transaction
        public void Register_Employee(Employee employee, List<SkillSet> skillset)
        {
            using (var context = new WorkScheduleContext())
            {
                employee.Active = true;

                employee = context.Employees.Add(employee);

                foreach(SkillSet skill in skillset)
                {
                    var newSkill = new EmployeeSkill();

                    newSkill.EmployeeID = employee.EmployeeID;
                    context.EmployeeSkills.Add(newSkill);
                }

                 context.SaveChanges();
            }
        }

        //Step two: Allow Insert of Skills
        //        [DataObjectMethod(DataObjectMethodType.Select)]
        //        public void Register_Employee(Employee employee, List<SkillSet> SkillSet)
        //        {

        //    //if (employee == null)
        //    //    throw new ArgumentNullException("employee", "Cannot insert skills, employee not given");

        //    using (var context = new WorkScheduleContext())
        //    {

        //        var emp = context.Employees.Find(employee.EmployeeID);
        //        if (emp == null)
        //            throw new Exception("Employee does not exist");
        //        var skillsInProcess = context.EmployeeSkills.Find(SkillSet.SkillID);
        //        if (skillsInProcess == null)
        //            skillsInProcess = context.EmployeeSkills.Add(new EmployeeSkill());
        //        else
        //            throw new Exception("Skills already there.");
        //        skillsInProcess.Employee.FirstName = employee.FirstName;
        //        skillsInProcess.Employee.LastName = employee.LastName;
        //        skillsInProcess.Employee.HomePhone = employee.HomePhone;

        //        skillsInProcess.SkillID = SkillSet.SkillID;
        //        skillsInProcess.Level = SkillSet.Level;
        //        skillsInProcess.YearsOfExperience = SkillSet.YOE;
        //        skillsInProcess.HourlyWage = SkillSet.HourlyWage;

        //        foreach (var detail in skillsInProcess.Skills)
        //        {

        //        }

        //        var newSkills = new EmployeeSkills()
        //        {
        //            FirstName = employee.FirstName,
        //            LastName = employee.LastName,
        //            HomePhone = employee.HomePhone,

        //            Skill = from item in newSkills.EmployeeSkills
        //                    select new SkillSet
        //                            {
        //                                employee.SkillID,
        //                                Level = employee.Level == 1 ? "Novice" : employee.Level == 2 ? "Proficient" : "Expert",
        //                                YearsOfExperience = employee.YearsOfExperience,
        //                                HourlyWage = employee.HourlyWage
        //                            }


        //        };
        //        context.EmployeeSkills.Add(newSkills);

        //        context.SaveChanges();

        //    }

        //}
    }
}

