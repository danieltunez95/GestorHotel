using Gh.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Create
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();
            string hotelString = Request.Form["hotel"] != null ? Request.Form["hotel"] : String.Empty;
            string[] hotel = hotelString.Split('/');
            List<Array> planta = new List<Array>();

            for (int i = 0; i < hotel.Length; i++)
            {
                planta.Add(hotel[i].Split(','));
            }
        }
    }
}