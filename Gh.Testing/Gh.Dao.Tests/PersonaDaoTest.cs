using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gh.Dao;
using Gh.Common;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class PersonaDaoTest
    {
        PersonaDao dao = null;
        static PersonaDto personaTest = null;

        public PersonaDaoTest()
        {
            dao = new PersonaDao();
        }

        [TestMethod]
        public void AddTest()
        {
            personaTest = new PersonaDto();
            personaTest.Nombre = "NombreTest";
            personaTest.PrimerApellido = "PrimerApellidoTest";
            personaTest.SegundoApellido = "SegundoApellidoTest";
            personaTest.Nif = "12345678R";
            personaTest.FechaNacimiento = new DateTime(1993, 8, 31);
            personaTest.Poblacion = new PoblacionDto() { Id = 1 };
            personaTest.Municipio = new MunicipioDto() { Id = 2 };
            personaTest.Pais = new PaisDto() { Id = 3 };
            personaTest.Direccion = "CalleTest";
            personaTest.Telefono = "902202122";

            PersonaDto persona = dao.Add(personaTest);
            Assert.IsTrue(persona != null && persona.Id != -1);
            personaTest.Id = persona.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<PersonaDto> personas = dao.GetAll();
            Assert.IsTrue(personas != null && personas.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            PersonaDto persona = dao.GetById(personaTest.Id);
            Assert.IsTrue(persona != null && persona.Id == personaTest.Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            personaTest.Nombre = "UpdateTest";
            personaTest.PrimerApellido = "ApellidoUpdateTest";
            personaTest.Poblacion.Id = 10;

            int result = dao.Update(personaTest);
            personaTest = dao.GetById(personaTest.Id);

            Assert.IsTrue(result == 1 && personaTest.Nombre.Equals("UpdateTest") && personaTest.PrimerApellido.Equals("ApellidoUpdateTest") && personaTest.Poblacion.Id == 10);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = dao.Delete(personaTest);
            personaTest = dao.GetById(personaTest.Id);
            Assert.IsTrue(result == 1 && personaTest == null);
        }
    }
}
