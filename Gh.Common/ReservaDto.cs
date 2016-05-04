using System;

namespace Gh.Common
{
    public class ReservaDto : BaseDto
    {
        public Guid ClienteGuid { get; set; }

        public int ClienteId { get; set; }

        public DateTime FechaReserva { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public float Precio { get; set; }

        public int Tipo { get; set; }
    }
}
