using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Create
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void actualizarButton_Click(object sender, EventArgs e)
        {
            HotelDto hotel = new HotelDto();
            hotel.Nombre = this.nombreBox.Text;
            hotel.Direccion = this.direccionBox.Text;
            hotel.Municipio = this.municipioBox.Text;
            hotel.Poblacion = this.poblacionBox.Text;

            HotelBus hotelBus = new HotelBus();
            hotelBus.Update(hotel);
        }
    }
}