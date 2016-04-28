using System;
using Hotel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hotel.Testing
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void GetHotel()
        {
            Common.Hotel hotel = new Common.Hotel();
            string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            string[] habitaciones = hotelString.Split('/');
            for (int i = 0; i < habitaciones.Length; i++)
            {
                string[] habitacion = habitaciones[i].Split(',');
                for (int j = 0; j < habitacion.Length; j++)
                {
                    if (habitacion[j].Equals("1"))
                    {
                        hotel.Habitaciones++;
                    }
                }
            }
            Assert.IsTrue(hotel.Habitaciones == 7);
        }
    }
}
