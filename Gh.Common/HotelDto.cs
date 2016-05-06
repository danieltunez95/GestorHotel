using System.Collections.Generic;

namespace Gh.Common
{
    public class HotelDto : BaseDto
    {
        /* Datos físicos */
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Municipio { get; set; }

        public string Poblacion { get; set; }

        //Is it really necessary?
        //public string Pais { get; set; }

        public List<HabitacionDto> Habitaciones { get; set; }

        public int Plantas { get; set; }

        
        //Needed in creation mode
        public int Ancho { get; set; }

        public int Largo { get; set; }

        public string Forma { get; set; }
    }
}
