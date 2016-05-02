using System;
using GestorHotel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GestorHotel.Dao;

namespace GestorHotel.Testing
{
    [TestClass]
    public class EmpleadoTest
    {
        EmpleadoDao dao = new EmpleadoDao();
        Empleado empleadoTest = new Empleado()
        {
            Guid = new Guid(),
            FechaInicio = new DateTime(2016, 1, 1),
            FechaNacimiento = new DateTime(1995, 2, 5),
            Nombre = "Eduardo",
            Apellido1 = "Manos",
            Apellido2 = "Tijeras",
            Oficio = new Oficio()
            {
                Guid = new Guid(),
                Trabajo = "Botones"
            }
        };

        [TestMethod]
        public void AddTest()
        {
            Empleado empleadoAdded = dao.Add(empleadoTest);
            Assert.IsTrue(empleadoAdded != null && empleadoAdded.Id != -1);
            empleadoTest.Id = empleadoAdded.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<Empleado> empleados = dao.GetAll();

            Assert.IsTrue(empleados != null && empleados.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Empleado empleadoNew = dao.GetById(empleadoTest.Id);
            Assert.IsTrue(empleadoNew != null && empleadoNew.Id == empleadoTest.Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Assert.IsTrue(empleadoTest.NombreCompleto != null);
            int result;
            empleadoTest.Oficio.Trabajo = "Camarero";
            result = dao.Update(empleadoTest);
            empleadoTest = dao.GetById(empleadoTest.Id);
            Assert.IsTrue(result == 1 && empleadoTest.Oficio.Trabajo.Equals("Camarero"));
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
