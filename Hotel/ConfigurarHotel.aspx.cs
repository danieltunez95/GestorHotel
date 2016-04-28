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
        int plantas;
        int ejeY;
        int ejeX;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            plantas = int.Parse(this.plantasTextBox.Text);
            ejeY = int.Parse(this.anchoTextBox.Text);
            ejeX = int.Parse(this.largoTextBox.Text);
            
            Response.Write("<table>");
            for (int x = 0; x < ejeX; x++)
            {
                Response.Write("<tr>");
                for (int y = 0; y < ejeY; y++)
                {
                    Response.Write("<td>");

                    Response.Write("<div class='celda' onclick='cellClick(this.id)' id='" + x + "_" + y + "'>");
                    Response.Write("</div>");

                    Response.Write("</td>");
                }
                Response.Write("</tr>");
            }
        }

        protected void Habitacion_Click(object sender, EventArgs e)
        {

        }

        protected void crearButton_Click(object sender, EventArgs e)
        {
            string[] array = this.matrizOculta.Value.Split(',');

            int contador = 0;
            for (int i = 0; i < contador; i++)
            {
            }
        }
    }
}