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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String nombre = ((Label)this.Master.FindControl("nombreHotel")).Text;
                //TODO: Implementar función
                //hotelId = hotelBus.GetIdByName(nombre);

                hotelId = 29;
            }
        }


        private string GetHotelTable(int hotelId, DateTime fechaInicio, DateTime fechaFinal)
        {
            StringBuilder table = new StringBuilder();

            HotelDto hotelDto = hotelBus.GetById(hotelId);

            table.Append("<table>");
            for (int i = 0; i < hotelDto.Ancho; i++)
            {
                table.Append("<tr>");
                for (int t = 0; t < hotelDto.Largo; t++)
                {
                    table.Append("<td>");
                    if (habitacionBus.isBusy(hotelId, i, t, 0, fechaInicio, fechaFinal))
                        table.Append("<div class='celda ocupada'></div>");
                    else
                        table.Append("<div class='celda libre'></div>");

                    table.Append("</td>");
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
                DateTime fechaInicio = DateTime.Parse(this.fechaInicioBox.Text);
                DateTime fechaFinal = DateTime.Parse(this.fechaFinalBox.Text);

                String representacion = GetHotelTable(hotelId, fechaInicio, fechaFinal);

                Response.Write(representacion);
            }
            catch
            {
                Response.Write("Ha ocurrido un error en el formato de las fechas. Compruebe los datos");
            }
        }
    }
}