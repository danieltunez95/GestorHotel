using Gh.Common;
using Gh.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class UsuarioDaoTest
    {
        UsuarioDao dao = null;
        static UsuarioDto usuarioTest = null;

        public UsuarioDaoTest()
        {
            dao = new UsuarioDao();
        }
        [TestMethod]
        public void AddTest()
        {
            usuarioTest = new UsuarioDto()
            {
                Username = "ChocoUser",
                Password = "ChocoPassword",
                Role = Role.RecursosHumanos,
                MinHour = 7,
                MaxHour = 8
            };
            UsuarioDto usuarioAdded = dao.Add(usuarioTest);

            Assert.IsTrue(usuarioAdded != null && usuarioAdded.Id != -1);
            usuarioTest.Id = usuarioAdded.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<UsuarioDto> usuarios = dao.GetAll();
            Assert.IsTrue(usuarios != null && usuarios.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            UsuarioDto usuario = dao.GetById(usuarioTest.Id);
            Assert.IsTrue(usuario != null && usuario.Id == usuarioTest.Id);
        }

        [TestMethod]
        public void GetByUsernameTest()
        {
            UsuarioDto usuario = dao.GetByUsername(usuarioTest.Username);
            Assert.IsTrue(usuario != null && usuario.Id == usuarioTest.Id && usuario.Username == usuarioTest.Username);
        }

        [TestMethod]
        public void UpdateTest()
        {
            usuarioTest.Role = Role.Ventas;
            usuarioTest.MinHour = 5;
            usuarioTest.MaxHour = 10;

            int result = dao.Update(usuarioTest);
            usuarioTest = dao.GetById(usuarioTest.Id);
            Assert.IsTrue(result == 1 && usuarioTest.Role == Role.Ventas && usuarioTest.MinHour == 5 
                && usuarioTest.MaxHour == 10);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = dao.Delete(usuarioTest);
            usuarioTest = dao.GetById(usuarioTest.Id);
            Assert.IsTrue(result == 1 && usuarioTest == null);
        }

        [TestMethod]
        public void LoginTest()
        {
            UsuarioDto usuario = dao.Login("viniadmin", "admin1234");
            Assert.IsTrue(usuario != null);
        }
    }
}
