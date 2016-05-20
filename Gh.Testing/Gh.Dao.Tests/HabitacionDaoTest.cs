using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Dao;

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
    }
}
