using System;

namespace Gh.Common
{
    public class EmpleadoDto : BaseDto
    {
        private string nombreCompleto;

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto
        {
            get
            {
                if (nombreCompleto != null)
                    nombreCompleto = String.Format("{0} {1}, {2}", PrimerApellido, SegundoApellido, Nombre);
                return nombreCompleto;
            }
            set { nombreCompleto = value; }
        }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaInicio { get; set; }

        public Oficio Oficio { get; set; }
    }
}
