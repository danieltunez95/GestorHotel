using System;
using GestorHotel.Common;

namespace GestorHotel
{
    public partial class CrearHotel : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();

        protected void Page_Load(object sender, EventArgs e)
        {
            hotel.Largo = Request.Form["largoTextBox"] != null ? int.Parse(Request.Form["largoTextBox"]) : 0;
            hotel.Ancho = Request.Form["anchoTextBox"] != null ? int.Parse(Request.Form["anchoTextBox"]) : 0;
            hotel.Plantas = Request.Form["plantasTextBox"] != null ? int.Parse(Request.Form["plantasTextBox"]) : 0;
        }

        protected void plantillaButton_Click(object sender, EventArgs e)
        {
            this.plantillaButton.Text = "Rehacer plantilla";
            hotel.Plantas = int.Parse(this.plantasTextBox.Text);
            hotel.Ancho = int.Parse(this.anchoTextBox.Text);
            hotel.Largo = int.Parse(this.largoTextBox.Text);
            
            Response.Write("<table>");
            for (int planta = 0; planta < hotel.Plantas; planta++)
            {
                for (int x = 0; x < hotel.Largo; x++)
                {
                    Response.Write("<tr>");
                    for (int y = 0; y < hotel.Ancho; y++)
                    {
                        Response.Write("<td>");

                        Response.Write("<div class='celda' onclick='cellClick(this.id)' id='" + x + "_" + y + "'>");
                        Response.Write("</div>");

                        Response.Write("</td>");
                    }
                    Response.Write("</tr>");
                }
            }
        }
    }
}