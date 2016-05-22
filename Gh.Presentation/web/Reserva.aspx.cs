using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.web
{
    public partial class Reserva : System.Web.UI.Page
    {
        static HotelBus hotelBus = new HotelBus();
        static HabitacionBus habitacionBus = new HabitacionBus();
        static HotelDto hotel;
        static int planta = 0;
        static DateTime fechaInicio;
        static DateTime fechaFinal;
        static int personas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String nombre = ((Label)this.Master.FindControl("nombreHotel")).Text;
                //hotel = hotelBus.GetByNombre(nombre);
            }
        }


        private string GetHotelTable(int hotelId, int planta, DateTime fechaInicio, DateTime fechaFinal)
        {
            StringBuilder habitaciones = new StringBuilder();

            int contador = 0;
            foreach (HabitacionDto habitacion in hotel.Habitaciones)
            {
                contador++;

                habitaciones.Append("[");
                habitaciones.Append(habitacion.Planta);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.PosicionX);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.PosicionY);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.Ocupada ? 1 : 0);
                habitaciones.Append("]");

                if (contador < hotel.Habitaciones.Count)
                    habitaciones.Append("|");
            }

            return habitaciones.ToString();
        }

        private string GetTable(int ancho, int largo)
        {
            StringBuilder table = new StringBuilder();
            table.Append("<table>");
            for (int x = 0; x <= hotel.Largo; x++)
            {
                table.Append("<tr>");
                for (int y = 0; y <= hotel.Ancho; y++)
                {
                    table.Append("<td> <div class='celda invisible' id='" + y + "_" + x + "'></div></td>");
                }
                table.Append("</tr>");
            }
            table.Append("</table>");

            return table.ToString();
        }
        protected void verButton_Click(object sender, EventArgs e)
        {
            try
            {
                fechaInicio = DateTime.Parse(this.fechaInicioBox.Text);
                fechaFinal = DateTime.Parse(this.fechaFinalBox.Text);
                personas = int.Parse(numeroPersonas.Text);
                // this.arrowUp.Visible = true;
                // this.arrowDown.Visible = false;
                double habitaciones = Math.Ceiling(personas / 2d);
                nueroHabitacionesLabel.InnerHtml = "Seleccione " + habitaciones.ToString() + (habitaciones > 1 ? " habitaciones" : "habitacion");


                //imprimo la tabla invisible
                string tabla = GetTable(hotel.Largo, hotel.Ancho);
                Panel tablaPanel = this.hotelTable;
                tablaPanel.Controls.Add(new LiteralControl(tabla));

                //paso el hotel al javascript
                string representacion = GetHotelTable(hotel.Id, planta, fechaInicio, fechaFinal);

                StringBuilder script = new StringBuilder();
                script.Append("<script onLoad='PrintHotel(0);'>");
                script.Append("var stringHotel = ('" + representacion + "');");
                script.Append("HOTEL = stringHotel.split('|');");
                script.Append("ULTIMA_PLANTA = " + hotel.Plantas + ";");
                script.Append("LARGO=" + hotel.Largo + ";");
                script.Append("ANCHO=" + hotel.Ancho + ";");
                script.Append("HABITACIONES=" + habitaciones + ";");
                script.Append("</script>");
            }
            catch
            {
                Response.Write("Ha ocurrido un error en el formato de las fechas. Compruebe los datos");
            }
        }

        protected void finalizarButton_Click(object sender, EventArgs e)
        {

        }
    }
}