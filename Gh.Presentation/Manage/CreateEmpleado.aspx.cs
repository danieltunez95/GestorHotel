﻿using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FechaNacimientoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            FechaNacimiento.Text = this.FechaNacimientoCalendar.SelectedDate.ToShortDateString();
        }

        protected void FechaContratoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            FechaContrato.Text = this.FechaContratoCalendar.SelectedDate.ToShortDateString();
        }

        protected void FechaExpiracionCalendar_SelectionChanged(object sender, EventArgs e)
        {
            FechaExpiracion.Text = this.FechaExpiracionCalendar.SelectedDate.ToShortDateString();
        }

        protected void crearButton_Click(object sender, EventArgs e)
        {
            EmpleadoDto empleado = new EmpleadoDto();
            empleado.Nombre = this.Nombre.Text;
            empleado.PrimerApellido = this.PrimerApellido.Text;
            empleado.SegundoApellido = this.SegundoApellido.Text;
            empleado.FechaNacimiento = DateTime.Parse(this.FechaNacimiento.Text);
            /* TODO: rellenar objeto persona */

            empleado.Oficio = (Oficio)Enum.Parse(typeof(Role), this.oficio.SelectedValue != "" ? this.oficio.SelectedValue : "0");
            empleado.FechaInicio = DateTime.Parse(this.FechaContrato.Text);

            EmpleadoBus empleadoBus = new EmpleadoBus();
            empleado = empleadoBus.Add(empleado);

            Response.Redirect("~/Manage/Empleados.aspx");
        }
    }
}