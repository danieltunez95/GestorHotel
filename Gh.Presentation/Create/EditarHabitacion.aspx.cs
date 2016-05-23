using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Gh.Presentation.Create
{
    public partial class EditarHabitacion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownTipoHabitacion();
                List<TipoHabitacionDto> tiposdeHabitacion = Session["TipoHabitaciones"] as List<TipoHabitacionDto>;
                this.DropDownTipoHabitacion.DataSource = tiposdeHabitacion;
                this.DropDownTipoHabitacion.DataTextField = "Nombre";
                this.DropDownTipoHabitacion.DataValueField = "Id";
                this.DropDownTipoHabitacion.DataBind();
            }
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            TipoHabitacionDto tipoHabitacion = new TipoHabitacionDto();
            tipoHabitacion.Nombre = this.NombreTipoHabitacion.Text;
            tipoHabitacion.MetrosCuadrados = Convert.ToInt32(this.MetrosCuadrados.Text);
            tipoHabitacion.Descripcion = this.Descripcion.Text;
            tipoHabitacion.Precio = Convert.ToDecimal(this.Precio.Text);

            TipoHabitacionBus tipoHabitacionBus = new TipoHabitacionBus();
            tipoHabitacion = tipoHabitacionBus.Add(tipoHabitacion);

            //Response.Redirect("~/Manage/Empleados.aspx");
        }

        protected void FillDropDownTipoHabitacion()
        {
            TipoHabitacionBus tipoHabitacionBus = new TipoHabitacionBus();
            List<TipoHabitacionDto> tipoHabitaciones = tipoHabitacionBus.GetAll();

            Session["TipoHabitaciones"] = tipoHabitaciones;
        }
    }
}