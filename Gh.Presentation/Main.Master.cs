using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UsuariosButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/Users.aspx");
        }

        protected void edicionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create/Main.aspx");
        }

        protected void empleadosButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/Empleados.aspx");
        }
    }
}