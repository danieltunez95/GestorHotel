using System.Collections.Generic;

namespace Gh.Common
{
    public class HotelDto : BaseDto
    {
        /* Datos físicos */
        public string Nombre { get; set; }

        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Poblacion { get; set; }

        public string Pais { get; set; }

        public List<HabitacionDto> Habitaciones { get; set; }

        public int Plantas { get; set; }

        public int Ancho { get; set; }

        public int Largo { get; set; }

        public string Forma { get; set; }
    }
}
