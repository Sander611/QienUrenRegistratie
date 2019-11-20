using Microsoft.AspNetCore.Mvc;
using Moq;
using QienHoursRegistration.Controllers;
using QienHoursRegistration.Models;
using QienHoursRegistration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestHoursRegistration
{
    public class Test_Client_Controller
    {
        [Fact]
        public async Task Get_Returns_AListOf_Clients()
        {
            // Arrange
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(repo => repo.Get())
                .ReturnsAsync(GetTestClients());
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var methodResult = Assert.IsType<List<Client>>(result);
        }
        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(repo => repo.Get())
                .ReturnsAsync(GetTestClients());
            var controller = new ClientController(mockRepo.Object);
            // Act
            var result = controller.GetAll().Result as List<Client>;

            // Assert
            var items = Assert.IsType<List<Client>>(result);
            Assert.Equal(2, items.Count);
        }
        [Fact]
        public async Task Create_ReturnsBadRequestResult_WhenModelState_IsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(repo => repo.Get())
                .ReturnsAsync(GetTestClients());
            var controller = new ClientController(mockRepo.Object);
            var newClient_No_CompanyName = new Client()
            {
                AccountId = 1,
                ClientId = 1,
                ClientName1 = "Peter Peter",
                ClientName2 = "Jan Jan",
                ClientEmail1 = "test@test.com",
                ClientEmail2 = "test1@test.com"
            };
            controller.ModelState.AddModelError("CompanyName", "Required");

            // Act
            var result = await controller.Create(newClient_No_CompanyName);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IClientRepository>();
            var controller = new ClientController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.Create(client: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task GetClientById_UnknownPassed_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistentClient = 123;
            var mockRepo = new Mock<IClientRepository>();
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = await controller.GetClientById(nonExistentClient);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Client>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
        [Fact]
        public async Task GetById_ExistingId_Returns_RightItem()
        {
            // Arrange
            int testClientId = 1;
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(repo => repo.GetById(testClientId))
                .ReturnsAsync(GetTestClients().FirstOrDefault(s => s.ClientId == testClientId));
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = await controller.GetClientById(testClientId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Client>>(result);
            var model = Assert.IsType<Client>(actionResult.Value);
            Assert.Equal(testClientId, model.ClientId);
            Assert.Equal("Macaw", model.CompanyName);
        }
        private List<Client> GetTestClients()
        {
            var clients = new List<Client>();
            clients.Add(new Client()
            {
                AccountId = 1,
                CompanyName = "Macaw",
                ClientId = 1,
                ClientName1 = "Peter Peter",
                ClientName2 = "Jan Jan",
                ClientEmail1 = "test@test.com",
                ClientEmail2 = "test1@test.com"
            });
            clients.Add(new Client()
            {
                AccountId = 2,
                CompanyName = "Booking.com",
                ClientId = 2,
                ClientName1 = "Gert-Jan",
                ClientName2 = "Baas",
                ClientEmail1 = "gert-jan@booking.com",
                ClientEmail2 = "baas@test.com"
            });
            return clients;
        }
    }
}
