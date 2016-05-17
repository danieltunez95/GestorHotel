using Gh.Bus;
using Gh.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Bus.Tests
{
    [TestClass]
    public class TurnoBusTest
    {
        TurnoBus turnoBus = null;
        static TurnoDto turnoTest = null;

        public TurnoBusTest()
        {
            turnoBus = new TurnoBus();
        }
        [TestMethod]
        public void AddTest()
        {
            turnoTest = new TurnoDto();
            turnoTest.Jornada = 40;
            turnoTest.Nombre = "Prueba Test";
            turnoTest.TurnoPrimeroInicio = "8:30";
            turnoTest.TurnoPrimeroFinal = "20:00";
            TurnoDto turnoAdded = turnoBus.Add(turnoTest);
            Assert.IsTrue(turnoAdded != null && turnoAdded.Id != -1);
            turnoTest.Id = turnoAdded.Id;
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result = 0;
            int jornada = 70;
            string nombre = "Prueba Test2";
            string turnoPrimeroInicio = "06:45";
            string turnoPrimeroFinal = "14:22";
            string turnoSegundoInicio = "18:01";
            string turnoSegundoFinal = "21:02";
            turnoTest.Jornada = jornada;
            turnoTest.Nombre = nombre;
            turnoTest.TurnoPrimeroInicio = turnoPrimeroInicio;
            turnoTest.TurnoPrimeroFinal = turnoPrimeroFinal;
            turnoTest.TurnoSegundoInicio = turnoSegundoInicio;
            turnoTest.TurnoSegundoFinal = turnoSegundoFinal;
            result = turnoBus.Update(turnoTest);
            Assert.IsTrue(result == 1 && turnoTest.Jornada == jornada && turnoTest.Nombre.Equals(nombre)
                && turnoTest.TurnoPrimeroInicio.Equals(turnoPrimeroInicio)
                && turnoTest.TurnoPrimeroFinal.Equals(turnoPrimeroFinal)
                && turnoTest.TurnoSegundoInicio.Equals(turnoSegundoInicio)
                && turnoTest.TurnoSegundoFinal.Equals(turnoSegundoFinal));
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<TurnoDto> turnos = turnoBus.GetAll();
            Assert.IsTrue(turnos != null && turnos.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            TurnoDto turno = turnoBus.GetById(turnoTest.Id);
            Assert.IsTrue(turno != null);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = turnoBus.Delete(turnoTest);
            turnoTest = turnoBus.GetById(turnoTest.Id);
            Assert.IsTrue(result == 1 && turnoTest == null);
        }
    }
}
