using System.Collections.Generic;

namespace Gh.Common
{
    public class HotelDto : BaseDto
    {
        /* Datos físicos */

        public string Direccion { get; set; }

        public MunicipioDto Municipio { get; set; }

        public PoblacionDto Poblacion { get; set; }

        public string Pais { get; set; }

        public List<HabitacionDto> Habitaciones { get; set; }

        public int Plantas { get; set; }

        public List<EmpleadoDto> Empleados { get; set; }

        public EmpleadoDto Propietario { get; set; }

        public int? Estrellas { get; set; }
        
        //Needed in creation mode
        public int Ancho { get; set; }

        public int Largo { get; set; }

        public string Forma { get; set; }
    }
}
