using System;

namespace GestorHotel.Common
{
    public class Empleado : Base
    {
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string nombreCompleto;
        private DateTime fechaNacimiento;
        private DateTime fechaInicio;
        private Oficio oficio;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido1
        {
            get { return apellido1; }
            set { apellido1 = value; }
        }

        public string Apellido2
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }

        public string NombreCompleto
        {
            get {
                nombreCompleto = String.Format("{0} {1}, {2}", Apellido1, Apellido2, Nombre);
                return nombreCompleto; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public Oficio Oficio
        {
            get { return oficio; }
            set { oficio = value; }
        }
    }
}