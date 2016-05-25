using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Demo.Create
{
    public partial class Editar : System.Web.UI.Page
    {
        static HotelDto hotel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Hotel"] != null)
                {
                    hotel = (HotelDto)Session["Hotel"];

                    this.plantasTextBox.Text = hotel.Plantas.ToString();
                    this.anchoTextBox.Text = hotel.Ancho.ToString();
                    this.largoTextBox.Text = hotel.Largo.ToString();
                    
                }
            }
        }
        protected void datosButton_Click(object sender, EventArgs e)
        {
            hotel.Plantas = int.Parse(this.plantasTextBox.Text);
            hotel.Ancho = int.Parse(this.anchoTextBox.Text);
            hotel.Largo = int.Parse(this.largoTextBox.Text);


            GenerarPlantilla(hotel);
        }

        private void GenerarPlantilla(HotelDto hotel)
        {
            StringBuilder plantilla = new StringBuilder();
            plantilla.Append("<table>");
            for (int x = 0; x < hotel.Largo; x++)
            {
                plantilla.Append("<tr>");
                for (int y = 0; y < hotel.Ancho; y++)
                {
                    plantilla.Append("<td>");

                    plantilla.Append("<div class='celda' id='" + x + "_" + y + "' onclick='cellClick(this.id)'>");
                    plantilla.Append("</div>");

                    plantilla.Append("</td>");
                }
                plantilla.Append("</tr>");
            }

            Panel graficoPanel = this.graficoPanel;
            graficoPanel.Controls.Add(new LiteralControl(plantilla.ToString()));
        }
    }
}