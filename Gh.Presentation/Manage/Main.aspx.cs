﻿using Gh.Bus;
using Gh.Common;
using System;
using System.Web.UI;

namespace Gh.Presentation.Manage
{
    public partial class Main1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();

            if (!IsPostBack && Session["hotel"] != null)
            {
                HotelDto hotel = (HotelDto)Session["hotel"];
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
