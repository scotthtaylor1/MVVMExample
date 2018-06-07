using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMExample.Controllers;
using MVVMExample.Models;
using MVVMExample.ViewModels;
using TestLibrary;

namespace MVVMExample.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest : BaseClass
    {
        public LoginControllerTest()
        {
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            LoginController loginController = new LoginController();
            var returnUrl = "";

            // Act
            var actionResult = loginController.Login(returnUrl) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(actionResult.Model, typeof(LoginModel));
        }

        [TestMethod]
        public void Login_TestDbReturn()
        {
            // Arrange
            var userID = "0";
            LoginViewModel viewModel = new LoginViewModel();
            LoginModel model = new LoginModel();
            model.Username = "staylor";
            model.ProtectedID = "123";
            model.Password = "123";

            // Act
            using (new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                userID = viewModel.login(model).ToString();
            }

            //Assert
            Assert.AreEqual("736", userID);
        }

        [TestMethod]
        public void CanGetSetSession()
        {
            using (new HttpSimulator("/", @"c:\inetpub\").SimulateRequest())
            {
                HttpContext.Current.Session["Test"] = "Success";
                Assert.AreEqual("Success", HttpContext.Current.Session["Test"], "Was not able to retrieve session variable.");
            }
        }
    }
}
