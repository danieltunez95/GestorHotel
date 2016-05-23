using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Dao;
using Gh.Common;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class ReservaDaoTest
    {
        ReservaDao dao = null;
        static ReservaDto reservaTest = null;

        public ReservaDaoTest()
        {
            dao = new ReservaDao();
        }

        [TestMethod]
        public void AddTest()
        {
            reservaTest = new ReservaDto();
            reservaTest.IdHotel = 60;
            reservaTest.IdHabitacion = 115;
            reservaTest.IdCliente = 1;
            reservaTest.Tipo = 1;
            reservaTest.FechaInicio = new DateTime(2016, 5, 23);
            reservaTest.FechaFinal = new DateTime(2016, 5, 25);
            reservaTest.FechaReserva = DateTime.Now;
            reservaTest.Importe = 5;
            reservaTest.Descuento = 0.5m;
            reservaTest.ImporteFinal = reservaTest.Importe - (reservaTest.Importe * reservaTest.Descuento);

            ReservaDto reserva = dao.Add(reservaTest);
            Assert.IsTrue(reserva != null && reserva.Id != -1);
        }
    }
}
