using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHotel.Common
{
    public class Reserva
    {
        private Guid guid;
        private Guid clienteGuid;
        private int id;
        private int clienteId;
        private DateTime fechaReserva;
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private float precio;
        private int tipo;

        public Guid Guid { get; set; }
        public Guid ClienteGuid { get; set; }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public float Precio { get; set; }
        public int Tipo { get; set; }
    }
}
