using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Gh.Presentation.Create
{
    public partial class EditarHabitacion : Page
    {
        TipoHabitacionBus tipoHabitacionBus = new TipoHabitacionBus();

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Hacer que las habitaciones se cambien cuando se seleccione.
            if (!IsPostBack)
            {
                FillDropDownTipoHabitacion();
                List<TipoHabitacionDto> tiposdeHabitacion = Session["TipoHabitaciones"] as List<TipoHabitacionDto>;
                this.DropDownTipoHabitacion.DataSource = tiposdeHabitacion;
                this.DropDownTipoHabitacion.DataTextField = "Nombre";
                this.DropDownTipoHabitacion.DataValueField = "Id";
                this.DropDownTipoHabitacion.DataBind();
                bool mostrarBotones = tiposdeHabitacion.Count > 0;
                this.editarButton.Visible = mostrarBotones;
                this.eliminarButton.Visible = mostrarBotones;
                this.replicarTodasButton.Visible = mostrarBotones;
                this.replicarSeleccionButton.Visible = mostrarBotones;
            }
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            TipoHabitacionDto tipoHabitacion = new TipoHabitacionDto();
            tipoHabitacion.Nombre = this.NombreTipoHabitacion.Text;
            tipoHabitacion.MetrosCuadrados = Convert.ToInt32(this.MetrosCuadrados.Text);
            tipoHabitacion.Descripcion = this.Descripcion.Text;
            tipoHabitacion.Precio = Convert.ToDecimal(this.Precio.Text.Replace(".", ","));
            try
            {
                tipoHabitacion = tipoHabitacionBus.Add(tipoHabitacion);
                //FillDropDownTipoHabitacion();
                this.TipoHabitacion.Visible = false;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        protected void FillDropDownTipoHabitacion()
        {
            List<TipoHabitacionDto> tipoHabitaciones = tipoHabitacionBus.GetAll();

            Session["TipoHabitaciones"] = tipoHabitaciones;
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.TipoHabitacion.Visible = true;
                this.createButton.Visible = false;
                this.editButton.Visible = true;
                TipoHabitacionDto tipoHabitacion = tipoHabitacionBus.GetById(Convert.ToInt32(this.DropDownTipoHabitacion.SelectedValue));
                this.NombreTipoHabitacion.Text = tipoHabitacion.Nombre;
                this.Descripcion.Text = tipoHabitacion.Descripcion;
                this.MetrosCuadrados.Text = tipoHabitacion.MetrosCuadrados.ToString();
                this.Precio.Attributes.Add("onkeydown", "javascript:return jsDecimals(event);");
                this.Precio.Text = tipoHabitacion.Precio.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void crearButton_Click(object sender, EventArgs e)
        {
            this.TipoHabitacion.Visible = true;
            this.createButton.Visible = true;
            this.editButton.Visible = false;
            this.NombreTipoHabitacion.Text = String.Empty;
            this.Descripcion.Text = String.Empty;
            this.MetrosCuadrados.Text = String.Empty;
            this.Precio.Attributes.Add("onkeydown", "javascript:return jsDecimals(event);");
            this.Precio.Text = String.Empty;
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                TipoHabitacionDto tipoHabitacion = tipoHabitacionBus.GetById(Convert.ToInt32(this.DropDownTipoHabitacion.SelectedValue));
                tipoHabitacionBus.Delete(tipoHabitacion);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                TipoHabitacionDto tipoHabitacion = new TipoHabitacionDto();
                tipoHabitacion.Id = Convert.ToInt32(this.DropDownTipoHabitacion.SelectedValue);
                tipoHabitacion.Nombre = this.NombreTipoHabitacion.Text;
                tipoHabitacion.Descripcion = this.Descripcion.Text;
                tipoHabitacion.MetrosCuadrados = Convert.ToInt32(this.MetrosCuadrados.Text);
                tipoHabitacion.Precio = Convert.ToDecimal(this.Precio.Text.Replace(".", ","));
                tipoHabitacionBus.Update(tipoHabitacion);
                this.TipoHabitacion.Visible = false;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void replicarTodasButton_Click(object sender, EventArgs e)
        {
            TipoHabitacionDto tipoHabitacion = tipoHabitacionBus.GetById(Convert.ToInt32(this.DropDownTipoHabitacion.SelectedValue));
            HabitacionBus habitacionBus = new HabitacionBus();

            HotelDto hotel = Session["hotel"] as HotelDto;
            try
            {
                int result = habitacionBus.UpdateTipoHabitacion(hotel.Id, tipoHabitacion);
                if (result != hotel.Habitaciones.Count)
                    throw new Exception("No se actualizaron todas.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void replicarSeleccionButton_Click(object sender, EventArgs e)
        {

        }
    }
}