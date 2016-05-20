using System;

namespace Gh.Common
{
    public class ReservaDto : BaseDto
    {
        public int IdHotel { get; set; }

        public int IdHabitacion { get; set; }

        public int IdCliente { get; set; }

        public int Tipo { get; set; }

        public string Comentario { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaReserva { get; set; }
        
        public decimal? Importe { get; set; }

        public decimal? Descuento { get; set; }

        public decimal? ImporteFinal { get; set; }
    }
}
