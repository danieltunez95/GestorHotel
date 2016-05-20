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
                if (!IsPostBack && Session["hotel"] != null)
                {
                    HotelDto hotel = hotelBus.GetById(29);
                    //Do everything
                    //Habitaciones disponibles
                    int habitaciones = 0;
                    if (hotel.Habitaciones != null)
                        habitaciones = hotel.Habitaciones.Count;

                    int reservas = hotelBus.GetReservasByIdHotel(hotel);
                    int entradas = hotelBus.GetEntradasByIdHotel(hotel);
                    int salidas = hotelBus.GetSalidasByIdHotel(hotel);

                    this.habitacionesLibresLabel.Text = (habitaciones - reservas).ToString();
                    this.habitacionesTotalLabel.Text = habitaciones.ToString();
                    this.entradasLabel.Text = entradas.ToString();
                    this.salidasLabel.Text = salidas.ToString();

                }
            }
        }
    }
}