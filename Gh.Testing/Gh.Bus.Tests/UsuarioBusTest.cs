using Gh.Bus;
using Gh.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Bus.Tests
{
    [TestClass]
    public class UsuarioBusTest
    {
        UsuarioBus usuarioBus = null;
        static UsuarioDto usuarioTest = null;

        public UsuarioBusTest()
        {
            usuarioBus = new UsuarioBus();
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
            UsuarioDto usuarioAdded = usuarioBus.Add(usuarioTest);

            Assert.IsTrue(usuarioAdded != null && usuarioAdded.Id != -1);
            usuarioTest.Id = usuarioAdded.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<UsuarioDto> usuarios = usuarioBus.GetAll();
            Assert.IsTrue(usuarios != null && usuarios.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            UsuarioDto usuario = usuarioBus.GetById(usuarioTest.Id);
            Assert.IsTrue(usuario != null && usuario.Id == usuarioTest.Id);
        }

        [TestMethod]
        public void GetByUsernameTest()
        {
            UsuarioDto usuario = usuarioBus.GetByUsername(usuarioTest.Username);
            Assert.IsTrue(usuario != null && usuario.Id == usuarioTest.Id && usuario.Username == usuarioTest.Username);
        }

        [TestMethod]
        public void UpdateTest()
        {
            usuarioTest.Role = Role.Ventas;
            usuarioTest.MinHour = 5;
            usuarioTest.MaxHour = 10;

            int result = usuarioBus.Update(usuarioTest);
            usuarioTest = usuarioBus.GetById(usuarioTest.Id);
            Assert.IsTrue(result == 1 && usuarioTest.Role == Role.Ventas && usuarioTest.MinHour == 5
                && usuarioTest.MaxHour == 10);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = usuarioBus.Delete(usuarioTest);
            usuarioTest = usuarioBus.GetById(usuarioTest.Id);
            Assert.IsTrue(result == 1 && usuarioTest == null);
        }
    }
}
