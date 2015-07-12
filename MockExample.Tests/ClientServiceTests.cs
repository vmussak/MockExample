using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockExample.Core.Client;
using MockExample.Core.Models;
using MockExample.Core.Notification;
using Moq;

namespace MockExample.Tests
{
    [TestClass]
    public class ClientServiceTests
    {
        [TestMethod]
        public void Deve_Retornar_Status_Error_Caso_Houver_Exception()
        {
            var mock = new Mock<IClientRepository>();

            mock.Setup(s => s.Get(It.IsAny<int>()))
                .Throws(new Exception("Testando qualquer erro de Banco de dados"));

            var client = new ClientService(mock.Object);
            var status = client.Get(15).Status;

            Assert.AreEqual(Status.Error, status);
        }

        [TestMethod]
        public void Deve_Retornar_Status_NoContent_Caso_Nao_Encontrar_Client()
        {
            var mock = new Mock<IClientRepository>();

            mock.Setup(s => s.Get(It.IsAny<int>()))
                .Returns(() => null);

            var client = new ClientService(mock.Object);
            var status = client.Get(15).Status;

            Assert.AreEqual(Status.NoContent, status);
        }

        [TestMethod]
        public void Deve_Retornar_Status_Ok_Caso_Encontrar_Client()
        {
            var mock = new Mock<IClientRepository>();

            mock.Setup(s => s.Get(It.IsAny<int>()))
                .Returns(new Client());

            var client = new ClientService(mock.Object);
            var status = client.Get(15).Status;

            Assert.AreEqual(Status.Ok, status);
        }
    }
}