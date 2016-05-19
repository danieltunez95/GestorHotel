using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Bus;
using Gh.Common;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Bus.Tests
{
    [TestClass]
    public class EmpleadoBusTest
    {
            EmpleadoBus bus = null;
            static EmpleadoDto empleadoTest = null;

            public EmpleadoBusTest()
            {
                bus = new EmpleadoBus();
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
                EmpleadoDto empleadoAdded = bus.Add(empleadoTest);
                Assert.IsTrue(empleadoAdded != null && empleadoAdded.Id != -1);
                empleadoTest.Id = empleadoAdded.Id;
            }

            [TestMethod]
            public void GetAllTest()
            {
                List<EmpleadoDto> empleados = bus.GetAll();

                Assert.IsTrue(empleados != null && empleados.Count > 0);
            }

            [TestMethod]
            public void GetByIdTest()
            {
                EmpleadoDto empleadoNew = bus.GetById(empleadoTest.Id);
                Assert.IsTrue(empleadoNew != null && empleadoNew.Id == empleadoTest.Id);
            }

            [TestMethod]
            public void UpdateTest()
            {
                int result;
                empleadoTest.Oficio = Oficio.Camarero;
                result = bus.Update(empleadoTest);
                empleadoTest = bus.GetById(empleadoTest.Id);
                Assert.IsTrue(result == 1 && empleadoTest.Oficio == Oficio.Camarero);
            }

            [TestMethod]
            public void DeleteTest()
            {
                int result;
                result = bus.Delete(empleadoTest);
                empleadoTest = bus.GetById(empleadoTest.Id);
                Assert.IsTrue(result == 1 && empleadoTest == null);
            }
        }
    }
