using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Common
{
    public class Reserva
    {
        private Guid id;
        private Guid clienteId;
        private DateTime fechaReserva;
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private float precio;
        private int tipo;

        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public float Precio { get; set; }
        public int Tipo { get; set; }
    }
}
