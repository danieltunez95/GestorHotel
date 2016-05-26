using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Demo.Manage
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Hotel"] != null)
            {
                HotelDto hotel = (HotelDto)Session["Hotel"];

                ClienteBus clienteBus = new ClienteBus();
                //TODO: Debería usarse clienteBus.GetAll(hotel). No tenemos hotelid en bd 'cliente'.
                this.clientesView.DataSource = clienteBus.GetAll();
                this.clientesView.DataBind();
            }
        }
    }
}