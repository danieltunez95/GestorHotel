using System;
using System.Web.UI;

namespace Gh.Presentation.Create
{
    public partial class Main : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void estructuraButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Demo/Create/Editar.aspx");
        }

        protected void habitacionesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Demo/Create/EditarHabitacion.aspx");
        }

        protected void detallesButton_Click(object sender, EventArgs e)
        {

        }
    }
}