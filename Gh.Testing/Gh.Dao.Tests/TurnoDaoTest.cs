using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Dao;
using Gh.Common;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class TurnoDaoTest
    {
        TurnoDao dao = null;
        TurnoDto turnoTest = null;
        static int id = -1;

        public TurnoDaoTest()
        {
            dao = new TurnoDao();
            turnoTest = new TurnoDto();
        }
        [TestMethod]
        public void AddTest()
        {
            turnoTest.Jornada = 40;
            turnoTest.Nombre = "Prueba Test";
            turnoTest.TurnoPrimeroInicio = "8:30";
            turnoTest.TurnoPrimeroFinal = "20:00";
            TurnoDto turnoAdded = dao.Add(turnoTest);
            Assert.IsTrue(turnoAdded != null && turnoAdded.Id != -1);
            id = turnoAdded.Id;
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result = 0;
            turnoTest.Jornada = 70;
            turnoTest.Nombre = "Prueba Test2";
            turnoTest.Id = 6;
            turnoTest.TurnoPrimeroInicio = "06:45";
            turnoTest.TurnoPrimeroFinal = "14:22";
            turnoTest.TurnoSegundoInicio = "18:01";
            turnoTest.TurnoSegundoFinal = "21:02";
            result = dao.Update(turnoTest);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<TurnoDto> turnos = dao.GetAll();
            Assert.IsTrue(turnos != null && turnos.Count > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            turnoTest.Id = 6;
            int result = dao.Delete(turnoTest);
            Assert.IsTrue(result == 1);
        }
    }
}
