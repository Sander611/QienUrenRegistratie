using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using QienHoursRegistration.

namespace UnitTestQienRegistration
{
    [TestClass]
    public class TestClientController
    {
        [Fact]
        public async Task ()
        {
            // Arrange
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        //private ClientController _sut;
        //[TestInitialize]
        //public void MyTestInitialize()
        //{
        //    var kernel = NinjectWebCommon.CreatePublicKernel();
        //    _sut = kernel.Resolve<ClientController>();
        //}
        //[TestMethod]
        //public void Then_Returns_ViewResult()
        //{
        //    //Arrange
        //    var homeController = new HomeController(new FakeProductRepository());
        //    //Act
        //    var result = homeController.BookInfo();
        //    //Assert
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}
        //[TestMethod]
        //public void Then_Returns_ProductViewModel()
        //{
        //    //Arrange
        //    var homeController = new HomeController(new FakeProductRepository());
        //    //Act
        //    var result = homeController.BookInfo() as ViewResult;
        //    //Assert
        //    Assert.IsInstanceOfType(result.Model, typeof(List<ProductViewModel>));
        //}
        //[TestMethod]
        //public void Then_Returns_Correct_Data()
        //{
        //    //Arrange
        //    var homeController = new HomeController(new FakeProductRepository());
        //    //Act
        //    var result = homeController.BookInfo() as ViewResult;
        //    var model = (List<ProductViewModel>)result.Model;
        //    //Assert
        //    Assert.IsTrue(model[0].Product_ID == 1);
        //}

    }
}
