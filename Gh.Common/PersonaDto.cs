using System;

namespace Gh.Common
{
    public class PersonaDto : BaseDto
    {
        private string nombreCompleto;

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

        public string Direccion { get; set; } // Plantearse hacerla un objeto, o que sea una lista.

        public string Telefono { get; set; } // Plantearse hacerlo una lista o un objeto.

        public string Nif { get; set; }

        public PoblacionDto Poblacion { get; set; }

        public MunicipioDto Municipio { get; set; }

        public PaisDto Pais { get; set; }
    }
}