using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Common
{
    public class Cliente
    {
        private Guid id;
        private string nombre;
        private string correo;

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}
