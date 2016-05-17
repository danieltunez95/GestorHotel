using Gh.Common;
using Gh.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class HotelDaoTest
    {
        HotelDao dao = null;
        static HotelDto hotelTest = null;

        public HotelDaoTest()
        {
            dao = new HotelDao();
        }

        [TestMethod]
        public void AddSinHabitacionesTest()
        {
            hotelTest = new HotelDto();
            HotelDto hotel = new HotelDto()
            {
                Nombre = "Hotel 10H 303",
                Poblacion = new PoblacionDto()
                {
                    Id = 5,
                    Nombre = "Salou"
                },
                Municipio = new MunicipioDto()
                {
                    Id = 2,
                    Nombre = "Reus",
                    Provincia = new ProvinciaDto() {  Id = 1, Nombre = "Tarragona", Pais = new PaisDto() { Id = 66, Nombre = "España"} }
                },
                Direccion = "Calle Bruselas 64",
                Propietario = new EmpleadoDto()
                {
                    Id = 1,
                    Nombre = "Daniel",
                    PrimerApellido = "Tuna",
                    SegundoApellido = "Eclesiastica",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    FechaInicio = new DateTime(2000, 1, 1),
                    Oficio = Oficio.Director
                },
                Estrellas = 3,
                Plantas = 4
            };
            //int numHab = 0;
            //hotel.Habitaciones = new List<HabitacionDto>();
            //string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            //string[] habitaciones = hotelString.Split('/');
            //for (int i = 0; i < habitaciones.Length; i++)
            //{
            //    string[] habitacion = habitaciones[i].Split(',');
            //    for (int j = 0; j < habitacion.Length; j++)
            //    {
            //        if (habitacion[j].Equals("1"))
            //        {
            //            numHab++;
            //            hotel.Habitaciones.Add(new HabitacionDto()
            //            {
            //                PosicionX = i,
            //                PosicionY = j,
            //                MetrosCuadrados = (i + 1) * (j + 1),
            //                Camas = 1,
            //                TipoCama = CamaEnum.Matrimonio,
            //                Precio = 25.23d,
            //                Dormitorios = 1,
            //                Descripcion = "Habitación normal",
            //                Planta = 0,
            //                Imagen = String.Format("../imagenes/habitacion{0}.jpg", numHab)
            //            });
            //        }
            //    }
            //}

            HotelDto hotelAdded = dao.Add(hotel);

            Assert.IsTrue(hotelAdded != null && hotelAdded.Id != -1);
            hotelTest = hotelAdded;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<HotelDto> hoteles = dao.GetAll();

            Assert.IsTrue(hoteles != null);
        }

        [TestMethod]
        public void GetById()
        {
            HotelDto hotel = dao.GetById(hotelTest.Id);
            Assert.IsTrue(hotel != null && hotel.Id != -1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = dao.Delete(hotelTest);
            hotelTest = dao.GetById(hotelTest.Id);
            Assert.IsTrue(result == 1 && hotelTest == null);
        }

        [TestMethod]
        public void UpdateTest()
        {
            string direccion = "Calibri 95";
            int estrellas = 1;
            int plantas = 20;
            hotelTest.Direccion = direccion;
            hotelTest.Estrellas = estrellas;
            hotelTest.Plantas = plantas;

            int result = dao.Update(hotelTest);
            hotelTest = dao.GetById(hotelTest.Id);
            Assert.IsTrue(result == 1 && hotelTest.Direccion.Equals(direccion) && hotelTest.Estrellas == estrellas 
                && hotelTest.Plantas == plantas);
        }

        [TestMethod]
        public void HasAnyHotelTest()
        {
            bool hasHotel = dao.HasAnyHotel();
            Assert.IsTrue(hasHotel == true);
        }

        [TestMethod]
        public void GetReservasByIdHotelTest()
        {
            int result = dao.GetReservasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetEntradasByIdHotelTest()
        {
            int result = dao.GetEntradasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetSalidasByIdHotelTest()
        {
            int result = dao.GetSalidasByIdHotel(new HotelDto() { Id = 29 });
            Assert.IsTrue(result >= 0);
        }
    }
}
