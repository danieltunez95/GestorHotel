using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHotel.Common
{
    public class Hotel
    {
        private Guid id;

        /* Datos físicos */
        private string nombre;
        private string calle;
        private string ciudad;
        private string poblacion;
        private string pais;

        private int habitaciones;
        private int plantas;

        private int ancho;
        private int largo;
        private string forma;

        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Poblacion { get; set; }
        public string Pais { get; set; }
        
        public int Habitaciones { get; set; }
        public int Plantas { get; set; }
        
        public int Ancho { get; set; }
        public int Largo { get; set; }
    }
}
