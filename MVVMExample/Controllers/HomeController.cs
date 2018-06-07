using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVVMExample.Controllers;

namespace MVVMExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                RedirectToAction("Login", "Login");
            else
            {
                //build menus here
            }

            return View();
        }
    }
}