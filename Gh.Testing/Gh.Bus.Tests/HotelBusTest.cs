using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Common;
using Gh.Bus;

namespace Gh.Testing.Gh.Bus.Tests
{
    [TestClass]
    public class HotelBusTest
    {
        HotelBus hotelBus = null;

        public HotelBusTest()
        {
            hotelBus = new HotelBus();
        }

        [TestMethod]
        public void GenerarPlantaFromStringTest()
        {
            string planta = "0,1,0,1/,1,1,1,1/0,0,1,1";
            HotelDto hotel = new HotelDto()
            {
                Plantas = 1
            };
            hotel = hotelBus.GenerarPlantaFromString(hotel, planta, 0);
        }
    }
}
