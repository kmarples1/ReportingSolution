using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkSchedule.Data.Entities.POCOs;
using WorkSchedule.System.BLL;

public partial class TransactionExercise_Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Register_OnClick(object sender, EventArgs e)
    {
            // 1) Build the EditCustomerOrder object from the form
            SkillList List = BuildSkillList();

            // 2) Send the object to the SalesController for bulk processing
            var controller = new EmployeeSkillController();
            controller.PlaceOrder(order);
            CustomerOrderEditingPanel.Enabled = false;
        }, "Place Order", "The customer order has been placed and is in queue for shipping.");
    }
}