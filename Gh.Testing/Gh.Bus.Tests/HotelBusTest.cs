using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Common;
using Gh.Bus;
using System.Collections.Generic;

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
            string planta = "0,1,0,1/1,1,1,1/0,0,1,1";
            HotelDto hotel = new HotelDto()
            {
                Plantas = 1
            };
            hotel = hotelBus.GenerarPlantaFromString(hotel, planta, 0);
            Assert.IsTrue(hotel.Habitaciones.Count == 8);
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<HotelDto> hoteles = hotelBus.GetAll();

            Assert.IsTrue(hoteles != null);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            HotelDto hotel = hotelBus.GetById(29);

            Assert.IsTrue(hotel != null && hotel.Habitaciones.Count > 0);
        }

        [TestMethod]
        public void HasAnyHotelTest()
        {
            bool hasHotel = hotelBus.HasAnyHotel();
            Assert.IsTrue(hasHotel == true);
        }

        [TestMethod]
        public void GetReservasByIdHotelTest()
        {
            int result = hotelBus.GetReservasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetEntradasByIdHotelTest()
        {
            int result = hotelBus.GetEntradasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetSalidasByIdHotelTest()
        {
            int result = hotelBus.GetSalidasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result > 0);
        }
    }
}
