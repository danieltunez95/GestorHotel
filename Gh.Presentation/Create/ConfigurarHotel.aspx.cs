using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Create
{
    public partial class ConfigurarHotel : System.Web.UI.Page
    {
        HotelDto hotel = new HotelDto();
        int plantaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            hotel.Largo = Request.Form["largoTextBox"] != null ? int.Parse(Request.Form["largoTextBox"]) : 0;
            hotel.Ancho = Request.Form["anchoTextBox"] != null ? int.Parse(Request.Form["anchoTextBox"]) : 0;
            hotel.Plantas = Request.Form["plantasTextBox"] != null ? int.Parse(Request.Form["plantasTextBox"]) : 0;

            if (hotel.Largo != 0 && hotel.Ancho != 0 && hotel.Plantas != 0)
            {
                //plantaActual = int.Parse(Request.Form["plantaActualTextBox"]);
                this.plantaActualTextBox.Text = "Planta " + plantaActual + " de " + hotel.Plantas;
                GenerarPlantilla(hotel);
            }
        }

        protected void plantillaButton_Click(object sender, EventArgs e)
        {
            this.plantillaButton.Text = "Rehacer plantilla";
            hotel.Plantas = int.Parse(this.plantasTextBox.Text);
            hotel.Ancho = int.Parse(this.anchoTextBox.Text);
            hotel.Largo = int.Parse(this.largoTextBox.Text);

            string plantilla = GenerarPlantilla(hotel);
            Response.Write(plantilla);
        }

        private string GenerarPlantilla(HotelDto hotel)
        {
            StringBuilder plantilla = new StringBuilder();
            plantilla.Append("<table>");
            for (int x = 0; x < hotel.Largo; x++)
            {
                plantilla.Append("<tr>");
                for (int y = 0; y < hotel.Ancho; y++)
                {
                    plantilla.Append("<td>");

                    plantilla.Append("<div class='celda' onclick='cellClick(this.id)' id='" + x + "_" + y + "'>");
                    plantilla.Append("</div>");

                    plantilla.Append("</td>");
                }
                plantilla.Append("</tr>");
            }
            return plantilla.ToString();
        }
    }
}