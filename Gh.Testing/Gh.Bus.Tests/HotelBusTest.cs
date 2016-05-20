using Gh.Bus;
using Gh.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Bus.Tests
{
    [TestClass]
    public class HotelBusTest
    {
        HotelBus hotelBus = null;
        ProvinciaBus provinciaBus = null;
        PaisBus paisBus = null;
        static HotelDto hotelTest = null;

        public HotelBusTest()
        {
            hotelBus = new HotelBus();
            provinciaBus = new ProvinciaBus();
            paisBus = new PaisBus();
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
        public void AddSinHabitacionesTest()
        {
            hotelTest = new HotelDto() {
                Direccion = "Calle de los choco",
                Estrellas = 5,
                Nombre = "Chocotel",
                Plantas = 3,
                Municipio = new MunicipioDto() { Id = 1},
                Poblacion = new PoblacionDto() { Id = 1, Nombre = "Chocotasticidad" },
                Propietario = new EmpleadoDto()
                {
                    Id = 1,
                    Persona = new PersonaDto()
                    {
                        Nombre = "ChocoBoy",
                        PrimerApellido = "ChocoTun",
                        SegundoApellido = "ChocoBer",
                        FechaNacimiento = new DateTime(1990, 1, 1)
                    },
                    Oficio = Oficio.Director,
                    FechaInicio = new DateTime(2000, 1, 1)
                },
            };

            HotelDto hotelAdded = hotelBus.Add(hotelTest);
            Assert.IsTrue(hotelAdded != null && hotelAdded.Id != -1);
            hotelTest = hotelAdded;
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
            HotelDto hotel = hotelBus.GetById(hotelTest.Id);

            Assert.IsTrue(hotel != null);
        }

        [TestMethod]
        public void UpdateTest()
        {
            string direccion = "Chocapic";
            int estrellas = 2;
            int plantas = 50;
            hotelTest.Direccion = direccion;
            hotelTest.Estrellas = estrellas;
            hotelTest.Plantas = plantas;

            int result = hotelBus.Update(hotelTest);
            hotelTest = hotelBus.GetById(hotelTest.Id); // Faltan implementar habitaciones para que no falle.
            Assert.IsTrue(hotelTest != null && hotelTest.Direccion.Equals(direccion) && hotelTest.Estrellas == estrellas
                && hotelTest.Plantas == plantas);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = hotelBus.Delete(hotelTest);
            hotelTest = hotelBus.GetById(hotelTest.Id);
            Assert.IsTrue(result == 1 && hotelTest == null);
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
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetEntradasByIdHotelTest()
        {
            int result = hotelBus.GetEntradasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetSalidasByIdHotelTest()
        {
            int result = hotelBus.GetSalidasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result >= 0);
        }
        [TestMethod]
        public void GetByNombreTest()
        {
            string nombre = "ViniDate Hotel";
            HotelDto hotel = hotelBus.GetByNombre(nombre);

            Assert.IsTrue(hotel != null && hotel.Habitaciones.Count > 0);
        }
    }
}
