using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMExample.Controllers;

namespace MVVMExample.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : BaseClass
    {
        public HomeControllerTest(string sessionVarName, string sessionValue):base(sessionVarName, sessionValue)
        {
        }

        public HomeControllerTest()
        {
        }
        
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            BaseClass baseClass = new BaseClass("UserID", "736");
            controller.ControllerContext = baseClass.controllerContext.Object;

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeController_RedirectToLoginControllerShouldBeTrue()
        {
            // Arrange
            HomeController controller = new HomeController();
            BaseClass baseClass = new BaseClass("UserID", "736");
            controller.ControllerContext = baseClass.controllerContext.Object;

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Index action result should not be null");
        }
    }
}
