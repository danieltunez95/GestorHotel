using Gh.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoBus turnoBus = new TurnoBus();
            this.turnosView.DataSource = turnoBus.GetTurnos();
            this.turnosView.DataBind();
        }

        protected void crearTurnoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/CreateTurno.aspx");
        }
    }
}