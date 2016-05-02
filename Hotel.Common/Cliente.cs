using System;

namespace GestorHotel.Common
{
    public class Cliente : Base
    {
        private string nombre;
        private string correo;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
    }
}
