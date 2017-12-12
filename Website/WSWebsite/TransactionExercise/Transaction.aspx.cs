using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkSchedule.Data.Entities;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.BLL;

public partial class TransactionExercise_Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
    }

    protected void Register_OnClick(object sender, EventArgs e)
    {

        Employee employee = new Employee();

        if (employee != null)
            throw new ArgumentNullException("employee", "Cannot register skills, employee exists");
        if (employee.FirstName == null)
            throw new ArgumentException("FirstName", "Cannot insert without a first name");
        if (employee.LastName == null)
            throw new ArgumentException("LastName", "Cannot insert without a last name");
        if (employee.HomePhone == null)
            throw new ArgumentException("Phone", "Cannot insert without a phone number");

        //if (employee.EmployeeSkills.SkillID.SelectedValue == null)
        //    throw new ArgumentException("Skill", "Cannot insert without skills");

        //if (employee.Level == null)
        //    throw new ArgumentException("Level", "Cannot insert without a level.");
        //if (employee.YOE == null)
        //    throw new ArgumentException("YOE", "Cannot insert without years of experience.");
        //if (employee.HourlyWage == null)
        //    throw new ArgumentException("HourlyWage", "Cannot insert without entering the hourly wage.");


        var container = newSkillsLV.InsertItem;

        var FirstName = container.FindControl("FirstName") as TextBox;
        var LastName = container.FindControl("LastName") as TextBox;
        var Phone = container.FindControl("Phone") as TextBox;
        var Level = container.FindControl("Level") as RadioButtonList;
        var YOE = container.FindControl("YOE") as TextBox;
        var HourlyWage = container.FindControl("HourlyWage") as TextBox;

        var skillset = new SkillSet
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Phone = employee.HomePhone,
            Level = Level.SelectedValue,
            YOE = int.Parse("YOE"),
            HourlyWage = decimal.Parse(HourlyWage.Text)
        };

         var controller = new EmployeeSkillController();

        controller.Register_Employee(employee, skillset);

        MessageLabel.Text = "Success, new employee skills added.";
                                  

    }

    protected void Clear_OnClick(object sender, EventArgs e)
    {
        FirstName = null;
        LastName = null;
        Phone = null;

    }



}