using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class Main1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();

            //If there are no hotels, go to the setup mode
            if (!hotelBus.HasAnyHotel())
                Response.Redirect("~/Create/CrearHotel.aspx");
            else
            {
                if (!IsPostBack)
                {
                    List<HotelDto> hoteles = new List<HotelDto>();
                    foreach (HotelDto hotel in hoteles)
                    {
                        //Do everything
                        //Habitaciones disponibles

                        int habitaciones = hotel.Habitaciones.Count;
                        int reservas = hotelBus.GetReservasByIdHotel(hotel.Id);

                        this.habitacionesInfosLabel.Text = String.Format(this.habitacionesInfosLabel.Text, reservas, habitaciones);
                       
                    }
                }
            }
        }
    }
}