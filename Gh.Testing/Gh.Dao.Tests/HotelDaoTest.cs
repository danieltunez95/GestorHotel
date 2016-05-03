using Gh.Common;
using Gh.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class HotelDaoTest
    {
        HotelDao dao = null;
        HotelDto hotelTest = null;

        public HotelDaoTest()
        {
            dao = new HotelDao();
            hotelTest = new HotelDto();
        }

        [TestMethod]
        public void GetAll()
        {
            hotelTest.Habitaciones = new List<HabitacionDto>();
            string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            string[] habitaciones = hotelString.Split('/');
            for (int i = 0; i < habitaciones.Length; i++)
            {
                string[] habitacion = habitaciones[i].Split(',');
                for (int j = 0; j < habitacion.Length; j++)
                {
                    if (habitacion[j].Equals("1"))
                    {
                        hotelTest.Habitaciones.Add(new HabitacionDto() { PosicionX = i, PosicionY = j, MetrosCuadrados = (i + 1) * (j + 1) });
                    }
                }
            }

            Assert.IsTrue(hotelTest.Habitaciones.Count == 7 && hotelTest.Habitaciones[1].PosicionX == 0 &&
                hotelTest.Habitaciones[1].PosicionY == 2 && hotelTest.Habitaciones[1].MetrosCuadrados == 3);
        }
    }
}
