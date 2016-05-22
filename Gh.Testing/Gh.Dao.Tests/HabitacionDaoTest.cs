using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Dao;
using Gh.Common;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class HabitacionDaoTest
    {
        HabitacionDao dao = null;

        public HabitacionDaoTest()
        {
            dao = new HabitacionDao();
        }
        [TestMethod]
        public void IsBusyTest()
        {
            int hotelId = 49;
            int posicionX = 0;
            int posicionY = 2;
            int planta = 0;
            DateTime fechaInicio = new DateTime(2016, 5, 13);
            DateTime fechaFinal = new DateTime(2016, 5, 14);
            bool ok = dao.isBusy(hotelId, posicionX, posicionY, planta, fechaInicio, fechaFinal);

            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void ExistHabitacion()
        {
            int hotelId = 49;
            int posicionX = 3;
            int posicionY = 2;
            int planta = 2;
            bool ok = dao.existHabitacion(hotelId, posicionX, posicionY, planta);

            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void AddTest()
        {
            HabitacionDto habitacion = new HabitacionDto()
            {
                HotelId = 1,
                Planta = 1,
                PosicionX = 1,
                PosicionY = 1,
                TipoHabitacion = new TipoHabitacionDto() { Id = 1}
            };

            habitacion = dao.Add(habitacion);
            Assert.IsTrue(habitacion.Id != -1);
        }

        [TestMethod]
        public void GetAllTest()
        {
            int id = 2;
            HabitacionDto habitacion = dao.GetById(id);
            Assert.IsTrue(habitacion != null);
        }
    }
}
