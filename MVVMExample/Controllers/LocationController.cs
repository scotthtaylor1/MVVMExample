using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVVMExample.Models;
using MVVMExample.ViewModels;
using Data;

namespace MVVMExample.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        // GET:  Location/ViewAllLocations
        public ActionResult ViewAllLocations()
        {
            LocationModel model = new LocationModel();
            List<Location> locations = Location.GetAllLocations(Session["SelectedCustomerID"].ToString(), Session["UserID"].ToString());

            if (locations != null)
            {
                model.Locations = locations;
            }

            return View(model);
        }

        public ActionResult GetLocationByID(int? locationID)
        {
            var location = Location.GetAllLocations(Session["SelectedCustomerID"].ToString(), Session["UserID"].ToString()).
                Where(x => x.LocationID == locationID);

            if(location != null)
            {
                LocationModel model = new Models.LocationModel();

                foreach (var item in location)
                {
                    model.LocationName = item.LocationName;
                    model.FullAddress = item.FullAddress;
                    model.ParentLocationName = item.ParentLocationName;
                }

                return View(model);
            }

            return View(); //Should never reach this
        }
    }
}