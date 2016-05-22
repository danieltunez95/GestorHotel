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
        static int hotelId;
        static HotelDto hotel;
        static int planta = 0;
        static DateTime fechaInicio;
        static DateTime fechaFinal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String nombre = ((Label)this.Master.FindControl("nombreHotel")).Text;
                //TODO: Implementar función
                hotel = hotelBus.GetByNombre(nombre);

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

               // this.arrowUp.Visible = true;
               // this.arrowDown.Visible = false;

                //imprimo la tabla invisible
                string tabla = GetTable(hotel.Largo, hotel.Ancho);
                Panel tablaPanel = this.hotelTable;
                tablaPanel.Controls.Add(new LiteralControl(tabla));

                //paso el hotel al javascript
                string representacion = GetHotelTable(hotelId, planta, fechaInicio, fechaFinal);
                Response.Write("<script onLoad='PrintHotel(0);'> var stringHotel = ('" + representacion + "'); HOTEL = stringHotel.split('|'); ULTIMA_PLANTA = " + hotel.Plantas + "; LARGO=" + hotel.Largo + "; ANCHO=" + hotel.Ancho + ";</script>");
            }
            catch
            {
                Response.Write("Ha ocurrido un error en el formato de las fechas. Compruebe los datos");
            }
        }
    }
}