using Gh.Bus;
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
        static HotelDto hotel = new HotelDto();
        static int plantaActual = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
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

        protected void crearHotelButton_Click(object sender, EventArgs e)
        {
            //TODO: Redirigir con parametro al encargado de finalizar la creacion y redirigir a Manage/Main.aspx
            Response.Redirect("~/Manage/Main.aspx");
        }

        protected void crearPlantaButton_Click(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();
            
            if (plantaActual <= hotel.Plantas)
            {
                string habitaciones = this.hiddenHotel.Value;
                hotel = hotelBus.GenerarPlantaFromString(hotel, habitaciones, plantaActual);
                plantaActual++;
                this.plantaActualTextBox.Text = plantaActual.ToString();
                GenerarPlantilla(hotel);
            }
            else
            {
                hotel = hotelBus.Add(hotel);
            }
        }
    }
}