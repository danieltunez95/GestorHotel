using System;

namespace Gh.Common
{
    public class EmpleadoDto : BaseDto
    {

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Oficio Oficio { get; set; }

        public PersonaDto Persona { get; set; }

        public TurnoDto Turno { get; set; }

        public decimal SalarioBruto { get; set; }

        public string CuentaBancaria { get; set; }
    }
}
