﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.DAL;

namespace WorkSchedule.System.BLL
{
    [DataObject]
    public class SkillsController
    {
        //Step one: List the skills
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SkillSet> Skills_List()
        {
            using (var context = new WorkScheduleContext())
            {
                var results = from data in context.Skills
                              select new SkillSet
                              {
                                  Skill = data.SkillID.ToString(),
                                  Description = data.Description
                              };

                return results.ToList();
            }
        }
    }
}
