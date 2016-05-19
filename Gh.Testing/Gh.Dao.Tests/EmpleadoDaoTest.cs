using Gh.Bus;
using Gh.Common;
using Gh.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class EmpleadoDaoTest 
    {
        EmpleadoDao dao = null;
        static EmpleadoDto empleadoTest = null;

        public EmpleadoDaoTest()
        {
            dao = new EmpleadoDao();
        }

        [TestMethod]
        public void AddTest()
        {
            empleadoTest = new EmpleadoDto()
            {
                FechaInicio = new DateTime(2016, 1, 1),
                Oficio = Oficio.Botones,
                CuentaBancaria = "2313EWFWSFSD",
                Persona = new PersonaDto() { Id = 1 },
                FechaFin = new DateTime(2016, 12, 31),
                SalarioBruto = 980,
                Turno = new TurnoDto() { Id = 1 }
            };
            EmpleadoDto empleadoAdded = dao.Add(empleadoTest);
            Assert.IsTrue(empleadoAdded != null && empleadoAdded.Id != -1);
            empleadoTest.Id = empleadoAdded.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<EmpleadoDto> empleados = dao.GetAll();

            Assert.IsTrue(empleados != null && empleados.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            EmpleadoDto empleadoNew = dao.GetById(empleadoTest.Id);
            Assert.IsTrue(empleadoNew != null && empleadoNew.Id == empleadoTest.Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result;
            empleadoTest.Oficio = Oficio.Camarero;
            result = dao.Update(empleadoTest);
            empleadoTest = dao.GetById(empleadoTest.Id);
            Assert.IsTrue(result == 1 && empleadoTest.Oficio == Oficio.Camarero);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result;
            result = dao.Delete(empleadoTest);
            empleadoTest = dao.GetById(empleadoTest.Id);
            Assert.IsTrue(result == 1 && empleadoTest == null);
        }
    }
}
