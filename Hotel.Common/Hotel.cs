﻿using System;
using System.Collections.Generic;

namespace GestorHotel.Common
{
    public class Hotel : Base
    {
        /* Datos físicos */
        private string nombre;
        private string calle;
        private string ciudad;
        private string poblacion;
        private string pais;

        private List<Habitacion> habitaciones;
        private int plantas;

        private int ancho;
        private int largo;
        private string forma;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public List<Habitacion> Habitaciones
        {
            get { return habitaciones; }
            set { habitaciones = value; }
        }

        public int Plantas
        {
            get { return plantas; }
            set { plantas = value; }
        }

        public int Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }

        public int Largo
        {
            get { return largo; }
            set { largo = value; }
        }

        public string Forma
        {
            get { return forma; }
            set { forma = value;}
        }
    }
}
