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
            public List<SkillSet> Skills_List()
            {
                using (var context = new WorkScheduleContext())
                {
                    var result = from data in context.EmployeeSkills
                                 select new SkillSet
                                 {
                                     Skill = data.Skill.Description,
                                     Level = data.Level == 1 ? "Novice" : data.Level == 2 ? "Proficient" : "Expert",
                                     YOE = data.YearsOfExperience,
                                     HourlyWage = data.HourlyWage
                                 };

                    return result.ToList();
                }
            }
        //Step two: Allow Update / Insert of Skills
        private void UpdatePendingOrder(SkillSet register)
        {
            using (var context = new WorkScheduleContext())
            {
                var registerInProcess = context.EmployeeSkills.Find(register.SkillID);
                if (registerInProcess == null)
                    throw new Exception("The order could not be found");
                // Make the orderInProcess match the customer order as given...
                // A) The general order information
                registerInProcess.SkillID = register.SkillID;
                //registerInProcess.Level = register.Level;
                registerInProcess.YearsOfExperience = register.YOE;
                registerInProcess.HourlyWage = register.HourlyWage;


                // B) Add/Update/Delete order details
                //    Loop through the items as known in the database (to update/remove)
                foreach (var detail in registerInProcess.SkillSet)
                {
                    var changes = register.SkillSet.SingleOrDefault(x => x.SkillID == detail.SkillID);
                    if (changes == null)
                        //toRemove.Add(detail);
                        context.Entry(detail).State = EntityState.Deleted; // flag for deletion
                    else
                    {
                        detail.Discount = changes.DiscountPercent;
                        detail.Quantity = changes.OrderQuantity;
                        detail.UnitPrice = changes.UnitPrice;
                        context.Entry(detail).State = EntityState.Modified;
                    }
                }
                //    Loop through the new items to add to the database
                foreach (var item in order.OrderItems)
                {
                    bool notPresent = !orderInProcess.OrderDetails.Any(x => x.ProductID == item.ProductId);
                    if (notPresent)
                    {
                        // Add as a new item
                        var newItem = new OrderDetail
                        {
                            ProductID = item.ProductId,
                            Quantity = item.OrderQuantity,
                            UnitPrice = item.UnitPrice,
                            Discount = item.DiscountPercent
                        };
                        orderInProcess.OrderDetails.Add(newItem);
                    }
                }

                // C) Save the changes (one save, one transaction)
                context.Entry(orderInProcess).State = EntityState.Modified;
                context.SaveChanges();
            }
        }




        //public void Register_Employee(SkillSet register)
        //{


        //    if (register == null)
        //        throw new ArgumentNullException("register", "Cannot place skills; register information was not supplied.");


        //    using (var context = new WorkScheduleContext())
        //    {
        //        var employee = context.EmployeeSkills.Add(new EmployeeSkill());
        //        if(employee == null)
        //            throw new Exception("Skill does not exist");

        //        var Registering = context.EmployeeSkills.Find(register.SkillID);
        //        if (Registering == null)
        //            Registering = context.EmployeeSkills.Add(new EmployeeSkill());

        //        // match this to employee entry as given...
        //        Registering.SkillID = register.SkillID;
        //        //Registering.Level = register.Level;
        //        Registering.YearsOfExperience = register.YOE;
        //        Registering.HourlyWage = register.HourlyWage;


        //        foreach (var item in register.Employee)
        //        {
        //            if (!orderInProcess.OrderDetails.Any(x => x.ProductID == item.ProductId))
        //            {
        //                // Add as a new item
        //                var newItem = new OrderDetail
        //                {
        //                    ProductID = item.ProductId,
        //                    Quantity = item.OrderQuantity,
        //                    UnitPrice = item.UnitPrice,
        //                    Discount = item.DiscountPercent
        //                };
        //                orderInProcess.OrderDetails.Add(newItem);
        //            }
        //        }
        //        context.SaveChanges();
        //    }
        //}

    }
}


