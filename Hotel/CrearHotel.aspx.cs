using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class CrearHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int plantas = int.Parse(this.plantasTextBox.Text);
            int ancho = int.Parse(this.anchoTextBox.Text);
            int largo = int.Parse(this.largoTextBox.Text);
            
            Response.Write("<table>");
            for (int x = 0; x < largo; x++)
            {
                Response.Write("<tr>");
                for (int y = 0; y < ancho; y++)
                {
                    Response.Write("<td>");

                    Response.Write("<div class='celda' onclick='cellClick(this.id)' id='" + x + "" + y + "'>");
                    Response.Write("</div>");

                    Response.Write("</td>");
                }
                Response.Write("</tr>");
            }
        }

        protected void Habitacion_Click(object sender, EventArgs e)
        {

        }
    }
}