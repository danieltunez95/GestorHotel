using Gh.Common;
using Gh.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Gh.Testing.Gh.Dao.Tests
{
    [TestClass]
    public class ClienteDaoTest
    {
        ClienteDao dao = null;
        static ClienteDto clienteTest = null;

        public ClienteDaoTest()
        {
            dao = new ClienteDao();
        }

        [TestMethod]
        public void AddTest()
        {
            clienteTest = new ClienteDto();
            clienteTest.Username = "alejoTest@test.com";
            clienteTest.Password = "abc123";
            clienteTest.Correo = "alejoTest@test.com";
            clienteTest.Telefono = "977392323";
            clienteTest.Persona = new PersonaDto();
            clienteTest.Persona.Id = 1;

            ClienteDto cliente = dao.Add(clienteTest);
            Assert.IsTrue(cliente != null && cliente.Id != -1);
            clienteTest.Id = cliente.Id;
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<ClienteDto> clientes = dao.GetAll();
            Assert.IsTrue(clientes != null && clientes.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            ClienteDto cliente = dao.GetById(clienteTest.Id);
            Assert.IsTrue(cliente != null && cliente.Id == clienteTest.Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            clienteTest.Telefono = "0000000";
            clienteTest.Username = "alejate@st.com";
            clienteTest.Correo = clienteTest.Username;

            int result = dao.Update(clienteTest);
            clienteTest = dao.GetById(clienteTest.Id);

            Assert.IsTrue(result == 1 && clienteTest.Telefono.Equals("0000000") && clienteTest.Username.Equals("alejate@st.com") && clienteTest.Correo.Equals("alejate@st.com"));
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = dao.Delete(clienteTest);
            clienteTest = dao.GetById(clienteTest.Id);
            Assert.IsTrue(result == 1 && clienteTest == null);
        }
    }
}
