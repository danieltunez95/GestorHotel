using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createEmployeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Demo/Manage/Demo/CreateEmpleado.aspx");
        }
    }
}