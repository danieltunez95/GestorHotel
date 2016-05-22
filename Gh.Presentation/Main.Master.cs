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
    public partial class Main : System.Web.UI.MasterPage
    {
        static HotelDto hotelActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();
            if (!IsPostBack)
            {
                List<HotelDto> hoteles = new List<HotelDto>();
                if (Session["hotel"] != null)
                {
                    hotelActual = (HotelDto)Session["hotel"];
                }
                else
                {
                    //añado espacio vacío
                    hoteles.Add(new HotelDto());
                }

                hoteles.AddRange(hotelBus.GetAll());

                this.hotelList.DataSource = hoteles;
                this.hotelList.DataTextField = "Nombre";
                this.hotelList.DataValueField = "Id";
                this.hotelList.DataBind();

                if (hotelActual != null)
                    this.hotelList.SelectedValue = hotelActual.Id.ToString();
            }

            if (!hotelBus.HasAnyHotel() && Page.ToString().ToLower().IndexOf("setup") == -1)
                Response.Redirect("/Create/Setup.aspx");
        }

        protected void IndexButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/Main.aspx");
        }

        protected void UsuariosButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/Users.aspx");
        }

        protected void edicionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Create/Main.aspx");
        }

        protected void empleadosButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage/Empleados.aspx");
        }

        protected void hotelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HotelBus hotelBus = new HotelBus();
            hotelActual = hotelBus.GetById(int.Parse(hotelList.SelectedValue));
            Session.Add("hotel", hotelActual);
        }
    }
}