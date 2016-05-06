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
    public partial class CreateTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Edit mode (parameter passed)

        }

        protected void crearTurnoButton_Click(object sender, EventArgs e)
        {
            TurnoDto turno = new TurnoDto();
            turno.Nombre = this.nombreBox.Text;
            turno.TurnoPrimeroInicio = this.turnoPrimeroInicioBox.Text;
            turno.TurnoSegundoInicio = this.turnoPrimeroFinalBox.Text;

            turno.TurnoSegundoInicio = this.turnoSegundoInicioBox.Text;
            turno.TurnoSegundoFinal = this.turnoSegundoFinalBox.Text;

            turno.Jornada = int.Parse(this.jornadaBox.Text);

            TurnoBus turnoBus = new TurnoBus();
            turnoBus.AddTurno(turno);

            Response.Redirect("~/Manage/Turnos.aspx");
        }
    }
}