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
                habitaciones.Append(habitacion.PosicionX);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.PosicionY);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.Planta);
                habitaciones.Append(",");
                habitaciones.Append(habitacion.Ocupada ? 1 : 0);
                habitaciones.Append("]");

                if (contador < hotel.Habitaciones.Count)
                    habitaciones.Append("|");
            }
            //table.Append("<table>");
            //for (int x = 0; x <= hotel.Ancho; x++)
            //{
            //    table.Append("<tr>");
            //    for (int y = 0; y <= hotel.Largo; y++)
            //    {
            //        table.Append("<td>");
            //       if (habitacionBus.existHabitacion(hotelId, x, y, planta))
            //       {
            //            if (habitacionBus.isBusy(hotelId, x, y, planta, fechaInicio, fechaFinal))
            //                table.Append("<div class='celda libre'></div>");
            //            else
            //                table.Append("<div class='celda ocupada' onclick = 'cellClick(this.id)' id = '" + x + "_" + y + "'></div>");
            //        }
            //        else
            //            table.Append("<div class='celda invisible'></div>");

            //        table.Append("</td>");
            //    }
            //    table.Append("</tr>");
            //}
            //table.Append("</table>");

            return habitaciones.ToString();
        }

        protected void verButton_Click(object sender, EventArgs e)
        {
            try
            {
                fechaInicio = DateTime.Parse(this.fechaInicioBox.Text);
                fechaFinal = DateTime.Parse(this.fechaFinalBox.Text);

                this.arrowUp.Visible = true;
                this.arrowDown.Visible = false;

                String representacion = GetHotelTable(hotelId, planta, fechaInicio, fechaFinal);
                Response.Write("<script> var stringHotel = ('" + representacion + "'); HOTEL = stringHotel.split('|'); printHotel(0); </script>");
            }
            catch
            {
                Response.Write("Ha ocurrido un error en el formato de las fechas. Compruebe los datos");
            }
        }
    }
}