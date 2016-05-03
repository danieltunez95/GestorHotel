using System;

namespace Gh.Common
{
    public class ReservaDto : BaseDto
    {
        private Guid clienteGuid;
        private int clienteId;
        private DateTime fechaReserva;
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private float precio;
        private int tipo;

        public Guid ClienteGuid
        {
            get { return clienteGuid; }
            set { clienteGuid = value; }
        }

        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }

        public DateTime FechaReserva
        {
            get { return fechaReserva; }
            set { fechaReserva = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFinal
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
