using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class CrearHotel1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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