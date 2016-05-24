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
    public partial class Setup : System.Web.UI.Page
    {
        static HotelDto hotel = new HotelDto();
        static int plantaActual = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plantillaButton_Click(object sender, EventArgs e)
        {
            this.plantillaButton.Text = "Rehacer plantilla";

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

        protected void crearHotelButton_Click(object sender, EventArgs e)
        {
            //TODO: Redirigir con parametro al encargado de finalizar la creacion y redirigir a Manage/Main.aspx
            Response.Redirect("~/Demo/Manage/Main.aspx");
        }

        protected void crearPlantaButton_Click(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();

            if (plantaActual <= hotel.Plantas)
            {
                string habitaciones = this.hiddenHotel.Text;
                hotel = hotelBus.GenerarPlantaFromString(hotel, habitaciones, plantaActual);
                GenerarPlantilla(hotel);
                plantaActual++;
                this.plantaActualTextBox.Text = plantaActual.ToString();

                if (plantaActual > hotel.Plantas)
                {
                    hotel = hotelBus.Add(hotel);
                    Response.Redirect("/Demo/Manage/Main.aspx");
                }
            }
            else
            {
                hotel = hotelBus.Add(hotel);
            }
        }

        protected void datosButton_Click(object sender, EventArgs e)
        {
            PaisBus paisBus = new PaisBus();
            hotel.Nombre = this.nombreBox.Text;
            hotel.Direccion = this.direccionBox.Text;
            hotel.Estrellas = int.Parse(this.estrellasBox.Text);

            //TODO: rellenar con dropdownlist
            hotel.Municipio = new MunicipioDto(1, "Tarragona");
            hotel.Poblacion = new PoblacionDto(1, "Tarragona");
            hotel.Pais = new PaisDto()
            {
                Id = 1,
                Nombre = "España"
            };


            hotel.Plantas = int.Parse(this.plantasTextBox.Text);
            hotel.Ancho = int.Parse(this.anchoTextBox.Text);
            hotel.Largo = int.Parse(this.largoTextBox.Text);

            UsuarioDto usuario = new UsuarioDto();
            usuario.Username = usuarioBox.Text;
            usuario.Password = passwordBox.Text;
            usuario.Role = Role.Administrador;
            usuario.MaxHour = 0;
            usuario.MinHour = 0;
            usuario.Email = emailBox.Text;

            //HotelBus hotelBus = new HotelBus();
            //hotelBus.Add(hotel);

            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.Add(usuario);

            this.datosPanel.Visible = false;
            this.fisicoPanel.Visible = true;
            this.anchoDisabledBox.Text = hotel.Ancho.ToString();
            this.largoDisabledBox.Text = hotel.Largo.ToString();
            this.plantasDisabledBox.Text = hotel.Plantas.ToString();

            GenerarPlantilla(hotel);
        }
    }
}
