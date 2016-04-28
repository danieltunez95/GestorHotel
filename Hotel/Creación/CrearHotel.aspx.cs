using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestorHotel
{
    public partial class CrearHotel1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hotelString = Request.Form["hotel"] != null ? Request.Form["hotel"] : String.Empty;

            if (!String.IsNullOrEmpty(hotelString)){
                string[] hotel = hotelString.Split('/');
                for (int i = 0; i < hotel.Length; i++)
                {
                    string[] habitaciones = hotel[i].Split(',');
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public static void Done(string ids)
        {
            String a = ids;
            string b = "";
            // Do whatever processing you want
        }
    }
}