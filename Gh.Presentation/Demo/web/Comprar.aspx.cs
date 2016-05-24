using Gh.Bus;
using Gh.Common;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.web
{
    public partial class Comprar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void finalizarButton_Click(object sender, EventArgs e)
        {
            String nombre = ((Label)this.Master.FindControl("nombreHotel")).Text;
            HotelBus hotelBus = new HotelBus();
            HotelDto hotel = hotelBus.GetByNombre(nombre);

            PersonaDto persona = new PersonaDto();
            persona.Nif = this.dniBox.Text;
            persona.Nombre = this.nombreBox.Text;
            persona.PrimerApellido = this.primerApellidoBox.Text;
            persona.SegundoApellido = this.segundoApellidoBox.Text;
            persona.Telefono = this.telefonoBox.Text;
            persona.FechaNacimiento = DateTime.Parse(this.fechaNacimiento.Text);
            PersonaBus personaBus = new PersonaBus();
            persona = personaBus.Add(persona);

            ClienteDto cliente = new ClienteDto();
            cliente.Correo = this.emailBox.Text;
            cliente.Username = this.emailBox.Text;
            cliente.Password = this.contraseñaBox.Text;
            cliente.Persona = persona;

            ClienteBus clienteBus = new ClienteBus();
            cliente = clienteBus.Add(cliente);

            String[] habitaciones = Request.QueryString["habitaciones"].Split(',');
            DateTime fechaInicio = DateTime.Parse(Request.QueryString["FechaInicio"]);
            DateTime fechaFinal = DateTime.Parse(Request.QueryString["fechaFinal"]);

            foreach (string habitacion in habitaciones)
            {
                string[] posicion = habitacion.Split('_');
                ReservaDto reserva = new ReservaDto();
                reserva.FechaInicio = fechaInicio;
                reserva.FechaFinal = fechaFinal;
                reserva.FechaReserva = DateTime.Now;
                reserva.IdCliente = cliente.Id;
                reserva.IdHotel = hotel.Id;
                reserva.IdPosHabitacion = hotel.Id + "_" + posicion[0] + "_" + posicion[1] +"_" + posicion[2];
                //TODO: some logic here
                reserva.Tipo = 0;
                reserva.Importe = 0;

                ReservaBus reservaBus = new ReservaBus();
                reservaBus.AddFromPos(reserva);
            }

            Response.Redirect("/Demo/web/UserPanel.aspx");
        }
    }
}