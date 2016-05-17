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
        EmpleadoDto empleadoTest = null;

        public EmpleadoDaoTest()
        {
            dao = new EmpleadoDao();
            empleadoTest = new EmpleadoDto()
            {
                FechaInicio = new DateTime(2016, 1, 1),
                FechaNacimiento = new DateTime(1995, 2, 5),
                Nombre = "Eduardo",
                PrimerApellido = "Manos",
                SegundoApellido = "Tijeras",
                Oficio = Oficio.Botones
            };
        }

        [TestMethod]
        public void AddTest()
        {
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
            Assert.IsTrue(empleadoTest.NombreCompleto != null);
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
