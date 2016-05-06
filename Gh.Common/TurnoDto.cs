using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Common
{
    public class TurnoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TurnoPrimeroInicio { get; set; }
        public string TurnoPrimeroFinal { get; set; }
        public string TurnoSegundoInicio { get; set; }
        public string TurnoSegundoFinal { get; set; }
        public int Jornada { get; set; }

        public static string DBName = "Turno";
    }
}
