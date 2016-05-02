using System;
using GestorHotel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GestorHotel.Testing
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void GetAll()
        {
            Hotel hotel = new Hotel();
            hotel.Habitaciones = new List<Habitacion>();
            string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            string[] habitaciones = hotelString.Split('/');
            for (int i = 0; i < habitaciones.Length; i++)
            {
                string[] habitacion = habitaciones[i].Split(',');
                for (int j = 0; j < habitacion.Length; j++)
                {
                    if (habitacion[j].Equals("1"))
                    {
                        hotel.Habitaciones.Add(new Habitacion() { PosicionX = i, PosicionY = j, MetrosCuadrados = (i + 1) * (j + 1) });
                    }
                }
            }
            
            Assert.IsTrue(hotel.Habitaciones.Count == 7 && hotel.Habitaciones[1].PosicionX == 0 &&
                hotel.Habitaciones[1].PosicionY == 2 && hotel.Habitaciones[1].MetrosCuadrados == 3);
        }
    }
}
