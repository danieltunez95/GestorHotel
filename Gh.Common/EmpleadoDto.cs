using System;

namespace Gh.Common
{
    public class EmpleadoDto : BaseDto
    {
        private string nombreCompleto;

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string NombreCompleto
        {
            get
            {
                nombreCompleto = String.Format("{0} {1}, {2}", Apellido1, Apellido2, Nombre);
                return nombreCompleto;
            }
            set { nombreCompleto = value; }
        }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaInicio { get; set; }

        public OficioDto Oficio { get; set; }
    }
}
