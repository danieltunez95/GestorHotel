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
                //hotelId = hotelBus.GetIdByName(nombre);

                hotelId = 49;
            }
        }


        private string GetHotelTable(int hotelId, int planta, DateTime fechaInicio, DateTime fechaFinal)
        {
            StringBuilder table = new StringBuilder();

            HotelDto hotelDto = hotelBus.GetById(hotelId);
            
            table.Append("<table>");
            for (int x = 0; x < hotelDto.Ancho; x++)
            {
                table.Append("<tr>");
                for (int y = 0; y < hotelDto.Largo; y++)
                {
                    table.Append("<td>");
                   if (habitacionBus.existHabitacion(x, y, planta, hotelId))
                   {
                        if (habitacionBus.isBusy(hotelId, x, y, planta, fechaInicio, fechaFinal))
                            table.Append("<div class='celda ocupada' onclick = 'cellClick(this.id)' id = '" + x + "_" + y + "'></div>");
                        else
                            table.Append("<div class='celda libre'></div>");
                   }

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
                fechaInicio = DateTime.Parse(this.fechaInicioBox.Text);
                fechaFinal = DateTime.Parse(this.fechaFinalBox.Text);

                this.arrowUp.Visible = true;
                this.arrowDown.Visible = false;
                PrintData();
            }
            catch
            {
                Response.Write("Ha ocurrido un error en el formato de las fechas. Compruebe los datos");
            }
        }

        private void PrintData()
        {

            String representacion = GetHotelTable(hotelId, planta, fechaInicio, fechaFinal);

            Panel hotelTable = this.hotelTable;
            hotelTable.Controls.Add(new LiteralControl(representacion));

            this.plantaActual.InnerText = "Planta " + planta;
        }

        protected void arrowUp_Click(object sender, ImageClickEventArgs e)
        {
            planta++;
            if (planta > 0)
                arrowDown.Visible = true;
            
            if (planta == hotel.Plantas - 1)
                arrowDown.Visible = false;

            PrintData();
        }

        protected void arrowDown_Click(object sender, ImageClickEventArgs e)
        {
            planta--;
            if (planta < hotel.Plantas)
                arrowDown.Visible = true;
            
            if (planta == 0)
                arrowDown.Visible = false;
            PrintData();
        }
    }
}