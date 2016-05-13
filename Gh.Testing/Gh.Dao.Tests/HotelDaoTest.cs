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
        HotelDto hotelTest = null;

        public HotelDaoTest()
        {
            dao = new HotelDao();
            hotelTest = new HotelDto();
        }

        [TestMethod]
        public void AddConHabitacionesTest()
        {
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
                    Nombre = "Reus"
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
            int numHab = 0;
            hotel.Habitaciones = new List<HabitacionDto>();
            string hotelString = "1,0,1,1/0,0,1,0/1,1,0,1";
            string[] habitaciones = hotelString.Split('/');
            for (int i = 0; i < habitaciones.Length; i++)
            {
                string[] habitacion = habitaciones[i].Split(',');
                for (int j = 0; j < habitacion.Length; j++)
                {
                    if (habitacion[j].Equals("1"))
                    {
                        numHab++;
                        hotel.Habitaciones.Add(new HabitacionDto()
                        {
                            PosicionX = i,
                            PosicionY = j,
                            MetrosCuadrados = (i + 1) * (j + 1),
                            Camas = 1,
                            TipoCama = CamaEnum.Matrimonio,
                            Precio = 25.23d,
                            Dormitorios = 1,
                            Descripcion = "Habitación normal",
                            Planta = 0,
                            Imagen = String.Format("../imagenes/habitacion{0}.jpg", numHab)
                        });
                    }
                }
            }

            HotelDto hotelAdded = dao.Add(hotel);

            Assert.IsTrue(hotelAdded != null && hotelAdded.Id != -1 && hotelAdded.Habitaciones.Count > 0);
        }

        [TestMethod]
        public void GetAllTest()
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

        [TestMethod]
        public void HasAnyHotelTest()
        {
            bool hasHotel = dao.HasAnyHotel();
            Assert.IsTrue(hasHotel == true);
        }
    }
}
